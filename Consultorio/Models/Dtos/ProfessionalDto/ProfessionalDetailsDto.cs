namespace Consultorio.Models.Dtos.ProfessionalDto
{
    public class ProfessionalDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int TotalAppointments { get; set; }
        public string[] Specialties { get; set; }
    }
}
