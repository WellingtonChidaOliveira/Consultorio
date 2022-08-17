using Consultorio.Context;
using Consultorio.Helpers;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repository
{
    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {

        private readonly ConsultorioContext _context;
        public ScheduleRepository(ConsultorioContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> Get(AppointmentParams parameter)
        {
            var appointment = _context.Appointments
                .Include(x => x.Patient)
                .Include(x => x.Professional)
                .Include(x => x.Speciality).AsQueryable();

            DateTime nullDate = new DateTime();
            if (parameter.StartDate != nullDate )
            {
                appointment = appointment.Where(x => x.DateHour >= parameter.StartDate);
            }
            if (parameter.EndDate != nullDate)
            {
                appointment = appointment.Where(x => x.DateHour >= parameter.EndDate);
            }

            if (string.IsNullOrEmpty(parameter.Speciality))
            {
                string nameSpeciality = parameter.Speciality.ToLower().Trim();
                appointment = appointment.Where(x => x.Speciality.Name.ToLower().Contains(nameSpeciality));
            }
                

            return await appointment.ToListAsync();
        }

        public async Task<Appointment> GetById(int id)
        {
            return await _context.Appointments
                .Include(x => x.Patient)
                .Include(x => x.Professional)
                .Include(x => x.Speciality)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

        }
    }
}
