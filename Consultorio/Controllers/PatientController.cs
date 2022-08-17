using AutoMapper;
using Consultorio.Models.PatientDto.Dtos;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Consultorio.Services;
using Microsoft.AspNetCore.Mvc;
using Consultorio.Models.Dtos.ScheduleDto;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientController(IPatientRepository repository, IMapper mapper)
        {
            _patientRepository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var patients = await _patientRepository.GetAsync();

            return patients.Any()
                ? Ok(patients)
                : BadRequest("There aren't patients");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patients = await _patientRepository.GetByIdAsync(id);
            var patientDetailsDto = _mapper.Map<PatientDetailsDto>(patients);

            return patients != null
                ? Ok(patientDetailsDto)
                : NotFound($"Not found patient {id}");
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddPatientDto patient)
        {
            if (patient == null) return BadRequest("Invalid data!");

            var patienteAdd = _mapper.Map<Patient>(patient);
            _patientRepository.Add(patienteAdd);

            return await _patientRepository.SaveChangesAsync()
                ? Ok("Success in save the patient")
                : BadRequest("Error saving patient");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AddPatientDto patient)
        {
            if (id <= 0) return BadRequest("Invalid patient");

            var patientBD = await _patientRepository.GetByIdAsync(id);
            if (patientBD == null) return NotFound("Patient not found");

            var UpdatePatient = _mapper.Map(patient,patientBD);

            _patientRepository.Update(UpdatePatient);

            return await _patientRepository.SaveChangesAsync()
               ? Ok("Success update patient")
               : BadRequest("Error update patient");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return BadRequest("Invalid patient");
            var patientBD = await _patientRepository.GetByIdAsync(id);
            if (patientBD == null) return NotFound("Patient not found");

            _patientRepository.Delete(patientBD);
            return await _patientRepository.SaveChangesAsync()
               ? Ok("Success delete patient")
               : BadRequest("Error delete patient");
        }
    }
}
