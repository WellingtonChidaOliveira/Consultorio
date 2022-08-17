using Consultorio.Context;
using Consultorio.Models.Dtos.SpecialityDto;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repository
{
    public class SpecialityRepository : BaseRepository, ISpecialityRepository
    {
        private readonly ConsultorioContext _context;
        public SpecialityRepository(ConsultorioContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SpecialitiesDto>> GetAllAsync()
        {
           return await _context.Specialties
                .Select(x => new SpecialitiesDto { Id = x.Id, Active = x.Active, Name = x.Name })
                .ToListAsync();
        }

        public async Task<Speciality> GetByIdAsync(int id)
        {
            return _context.Specialties
                .Include(x => x.Professionals)
                .Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
