using Consultorio.Helpers;
using Consultorio.Models.Entities;

namespace Consultorio.Repository.Interfaces
{
    public interface IScheduleRepository : IBaseRepository
    {
        Task<IEnumerable<Appointment>> Get(AppointmentParams parameter);
        Task<Appointment> GetById(int id);

    }
}
