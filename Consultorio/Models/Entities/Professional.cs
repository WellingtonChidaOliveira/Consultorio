namespace Consultorio.Models.Entities
{
    public class Professional : Base 
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Speciality> Specialties { get; set; }
    }
}
