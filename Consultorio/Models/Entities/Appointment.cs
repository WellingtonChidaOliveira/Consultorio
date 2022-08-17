namespace Consultorio.Models.Entities
{
    public class Appointment : Base
    {
        public DateTime DateHour { get; set; }
        public int Status { get; set; }
        public decimal Price { get; set; }
        public int PatientId { get; set; }
        public  Patient Patient { get; set; }
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }
        public int ProfessionalId { get; set; }
        public Professional Professional { get; set; }
    }
}
