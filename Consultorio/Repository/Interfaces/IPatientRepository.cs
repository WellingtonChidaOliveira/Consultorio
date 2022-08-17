using Consultorio.Models.PatientDto.Dtos;
using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
    public interface IPatientRepository : IBaseRepository
    {
       Task< IEnumerable<PatientsDto>> GetAsync();
        Task<Patient> GetByIdAsync(int id);

    }
}
