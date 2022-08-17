using Consultorio.Models.Dtos.SpecialityDto;
using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
    public interface ISpecialityRepository : IBaseRepository
    {
        Task<IEnumerable<SpecialitiesDto>> GetAllAsync();
        Task<Speciality> GetByIdAsync(int id);
    }
}
