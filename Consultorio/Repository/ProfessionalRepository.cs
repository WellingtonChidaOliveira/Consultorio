using Consultorio.Context;
using Consultorio.Models.Dtos.ProfessionalDto;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repository
{
    public class ProfessionalRepository : BaseRepository, IProfessionalRepository
    {
        private readonly ConsultorioContext _context;

        public ProfessionalRepository(ConsultorioContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProfessionalsDto>> GetAll()
        {
            return await _context.Professionals
                .Select(x => new ProfessionalsDto { Id = x.Id, Name = x.Name, Active = x.Active }).ToListAsync();
        }

        public async Task<Professional> GetById(int id)
        {
            return await _context.Professionals
                 .Include(x => x.Appointments)
                 .Include(x => x.Specialties)
                 .Where(x => x.Id == id).FirstOrDefaultAsync(); 

                
        }

        public async Task<ProfessionalSpecialty> GetProfessionalSpeciality(int professionalId, int specialityId)
        {
            return await _context.ProfessionalSpeciality
                .Where(x => x.ProfessionalId == professionalId && x.SpecialtyId == specialityId)
                .FirstOrDefaultAsync();
        }
    }
}
