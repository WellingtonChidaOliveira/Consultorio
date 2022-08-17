namespace Consultorio.Models.Dtos.ScheduleDto;

public class AppointmentDto
{
    public int Id { get; set; }
    public DateTime DateHour { get; set; }
    public int Status { get; set; }
    public decimal Price { get; set; }
    public string Speciality { get; set; }
    public string Professional { get; set; }
}

