using Consultorio.Models.Dtos.ProfessionalDto;
using Consultorio.Models.Dtos.SpecialityDto;
using Consultorio.Models.PatientDto.Dtos;

namespace Consultorio.Models.Dtos.ScheduleDto
{
    public class ScheduleDetailsDto
    {
        public int Id { get; set; }
        public DateTime DateHour { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }
        public SpecialitiesDto Speciality { get; set; }
        public ProfessionalsDto Professional { get; set; }
        public PatientsDto Patient { get; set; }
    }
}
