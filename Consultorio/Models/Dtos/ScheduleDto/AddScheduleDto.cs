namespace Consultorio.Models.Dtos.ScheduleDto
{
    public class AddScheduleDto
    {
        public DateTime DateHour { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }
        public int PatientId { get; set; }
        public int SpecialityId { get; set; }
        public int ProfessionalId { get; set; }

    }
}
