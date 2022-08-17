using Consultorio.Models.Dtos.ScheduleDto; 

namespace Consultorio.Models.PatientDto.Dtos
{
    public class PatientDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
    }
}
