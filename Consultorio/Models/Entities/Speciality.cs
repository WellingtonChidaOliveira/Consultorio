namespace Consultorio.Models.Entities
{
    public class Speciality : Base
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public List<Professional> Professionals { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
