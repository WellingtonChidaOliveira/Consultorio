namespace Consultorio.Models.Dtos.ScheduleDto
{
    public class UpdateScheduleDto
    {
        public DateTime DateHour { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }

        public string ProfessionalId { get; set; }
    }
}
