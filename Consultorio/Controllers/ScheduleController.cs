using AutoMapper;
using Consultorio.Helpers;
using Consultorio.Models.Dtos.ScheduleDto;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ScheduleController : ControllerBase
    {

        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;
        public ScheduleController(IScheduleRepository repository, IMapper mapper)
        {
            _scheduleRepository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]AppointmentParams parameter)
        {
            var schedule = await _scheduleRepository.Get(parameter);

            var scheduleRet = _mapper.Map<IEnumerable<ScheduleDetailsDto>>(schedule);

            return scheduleRet.Any()
                ? Ok(scheduleRet)
                : NotFound("Appointment not found");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest("Invalid appointment");
            var schedule = await _scheduleRepository.GetById(id);
            if (schedule == null) return NotFound("Not found");
            var scheduleRet = _mapper.Map<ScheduleDetailsDto>(schedule);

            return scheduleRet != null
                ? Ok(scheduleRet)
                : NotFound("Appointment not found");
        }

        [HttpPost]

        public async Task<IActionResult> Post(AddScheduleDto schedule)
        {
            if (schedule == null) return BadRequest("Invalid data");

            var appointment = _mapper.Map<Appointment>(schedule);

            _scheduleRepository.Update(appointment);

            return await _scheduleRepository.SaveChangesAsync()
                ? Ok("Succes schedule appointment")
                : NotFound("Error schedule appointment");


        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateScheduleDto schedule)
        {
            if (id <= 0) return BadRequest("Invalid appointment");
            var scheduleBd = await _scheduleRepository.GetById(id);
            if (scheduleBd == null) return NotFound("Not found");

            if(schedule.DateHour == new DateTime())
            {
                schedule.DateHour = scheduleBd.DateHour;
            }
            var updateSchedule = _mapper.Map(schedule,scheduleBd);
            _scheduleRepository.Update(updateSchedule);

            return await _scheduleRepository.SaveChangesAsync()
               ? Ok("Succes update schedule appointment")
               : NotFound("Error update schedule appointment");
        }
    }
}
