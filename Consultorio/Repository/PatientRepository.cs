using Consultorio.Context;
using Consultorio.Models.PatientDto.Dtos;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repository
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        private readonly ConsultorioContext _context;

        public PatientRepository(ConsultorioContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<PatientsDto>> GetAsync()
        {
            return  await _context.Patients
                .Select(x => new PatientsDto { Id = x.Id, Name = x.Name })
                .ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients
                .Include(x => x.Appointments).ThenInclude(c=> c.Speciality)
                .Include(x => x.Appointments).ThenInclude(c=> c.Professional)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

    }
}
