using Consultorio.Models.Dtos.ProfessionalDto;
using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
    public interface IProfessionalRepository : IBaseRepository
    {
        Task<IEnumerable<ProfessionalsDto>> GetAll();

        Task<Professional> GetById(int id);

        Task<ProfessionalSpecialty> GetProfessionalSpeciality(int professionalId, int specialityId);
    }
}
