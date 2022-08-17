using AutoMapper;
using Consultorio.Models.Dtos.SpecialityDto;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialityController : ControllerBase
    {
        private readonly ISpecialityRepository _specialityRepository;
        private readonly IMapper _mapper;
        public SpecialityController(ISpecialityRepository repository, IMapper mapper)
        {
            _specialityRepository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var specialities = await _specialityRepository.GetAllAsync();
            return specialities.Any()
                ? Ok(specialities)
                : NotFound("Not found specialities");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest("Invalid speciality");

            var specility = await _specialityRepository.GetByIdAsync(id);

            var specliatyDto = _mapper.Map<SpecialityDetailsDto>(specility);

            return specliatyDto != null
                ? Ok(specliatyDto)
                : NotFound("Not found speciality");
        }
        [HttpPost]
        public async Task<IActionResult> Post(AddSpecialityDto speciality)
        {
            var addSpeciality = _mapper.Map<Speciality>(speciality);

            _specialityRepository.Add(addSpeciality);
            return await _specialityRepository.SaveChangesAsync()
                ? Ok("Success create speciality")
                : BadRequest("Failed create speciality");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AddSpecialityDto speciality)
        {
            if (id <= 0) return BadRequest("Invalid speciality");
            var specialityBd = await _specialityRepository.GetByIdAsync(id);
            if (specialityBd == null) return NotFound("Not found speciality");

            var UpdateSpeciality = _mapper.Map(speciality, specialityBd);
            _specialityRepository.Update(UpdateSpeciality);

            return await _specialityRepository.SaveChangesAsync()
                ? Ok("Success update speciality")
                : BadRequest("Failed update speciality");
        }

        [HttpPut("{id}/update-status/")]
        public async Task<IActionResult> Put(int id, bool active)
        {
            if (id <= 0) return BadRequest("Invalid speciality");
            var specialityBd = await _specialityRepository.GetByIdAsync(id);
            if (specialityBd == null) return NotFound("Not found speciality");


            var status = active ? "active" : "Inactive";
            if (specialityBd.Active == active) return Ok($"Speciality alredy {status}");

            specialityBd.Active = active;
            _specialityRepository.Update(specialityBd);
            return await _specialityRepository.SaveChangesAsync()
               ? Ok("Success update status speciality")
               : BadRequest("Failed update status speciality");
        }


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (id <= 0) return BadRequest("Invalid speciality");
        //    var specialityBd = await _specialityRepository.GetByIdAsync(id);
        //    if (specialityBd == null) return NotFound("Not found speciality");

        //    _specialityRepository.Delete(specialityBd);
        //    return await _specialityRepository.SaveChangesAsync()
        //        ? Ok("Success delete speciality")
        //        : BadRequest("Failed delete speciality");
        //}

    }
}
