using AutoMapper;
using Consultorio.Models.Dtos.ProfessionalDto;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessionalController : ControllerBase
    {
        private readonly IProfessionalRepository _professionalRepository;
        private readonly IMapper _mapper;

        public ProfessionalController(IProfessionalRepository repository, IMapper mapper)
        {
            _professionalRepository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var professionals = await _professionalRepository.GetAll();
            return professionals.Any()
                ? Ok(professionals)
                : NotFound("Not Found Professionals");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest("Invalid Professional");

            var professional = await _professionalRepository.GetById(id);
            if (professional == null) NotFound("Not found professional");

            var professionalDetails = _mapper.Map<ProfessionalDetailsDto>(professional);

            return professionalDetails != null
                ? Ok(professionalDetails)
                : NotFound("Not Found Professional");
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddProfessionalDto professional)
        {
            if (string.IsNullOrEmpty(professional.Name)) return BadRequest("Name is required");

            var addProfessional = _mapper.Map<Professional>(professional);
            _professionalRepository.Add(addProfessional);

            return await _professionalRepository.SaveChangesAsync()
                ? Ok("Success create professional")
                : BadRequest("Error create professional");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(AddProfessionalDto professional, int id)
        {
            if (id <= 0) return BadRequest("Invalid professional");
            if (string.IsNullOrEmpty(professional.Name)) return BadRequest("Invalid professional");

            var professionalBd = await _professionalRepository.GetById(id);
            if (professionalBd == null) return NotFound("Not found professional");

            var updateProfessional = _mapper.Map(professional, professionalBd);

            _professionalRepository.Update(updateProfessional);
            return await _professionalRepository.SaveChangesAsync()
               ? Ok("Success update professional")
               : BadRequest("Error update professional");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid professional");
            var professionalBd = await _professionalRepository.GetById(id);
            if (professionalBd == null) return NotFound("Not found professional");
            _professionalRepository.Delete(professionalBd);
            return await _professionalRepository.SaveChangesAsync()
              ? Ok("Success delete professional")
              : BadRequest("Error delete professional");
        }

        [HttpPost("add-professional")]
        public async Task<IActionResult> PostProfessionalSpeciality(ProfessionalSpecialityDto ps)
        {
            if (ps.ProfessionalId <= 0 || ps.SpecialtyId <= 0) BadRequest("Invalid data");

            var professionalSpeciality = await _professionalRepository.GetProfessionalSpeciality(ps.ProfessionalId, ps.SpecialtyId);
            if (professionalSpeciality != null) return Ok("Speciality alredy exist");

            var addProfissionalSpeciality = new ProfessionalSpecialty
            {
                SpecialtyId = ps.SpecialtyId,
                ProfessionalId = ps.ProfessionalId,
            };

            _professionalRepository.Add(addProfissionalSpeciality);
            return await _professionalRepository.SaveChangesAsync()
             ? Ok("Success add professional speciality")
             : BadRequest("Error add professional speciality");


        }

        [HttpDelete("{professionalId}/deletar-speciality/{specialityId}")]
        public async Task<IActionResult> DeleteProfessionalSpeciality(int professionalId, int specialityId)
        {
            if (professionalId <= 0 || specialityId <= 0) BadRequest("Invalid data");
            var professionalSpeciality = await _professionalRepository.GetProfessionalSpeciality(professionalId, specialityId);
            if (professionalSpeciality == null) return NotFound("Speciality not found");

            _professionalRepository.Delete(professionalSpeciality);
            return await _professionalRepository.SaveChangesAsync()
            ? Ok("Success delete professional speciality")
            : BadRequest("Error delete professional speciality");
        }
    }
}
