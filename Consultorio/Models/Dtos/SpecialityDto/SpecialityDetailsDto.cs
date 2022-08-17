using Consultorio.Models.Dtos.ProfessionalDto;

namespace Consultorio.Models.Dtos.SpecialityDto
{
    public class SpecialityDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public List<ProfessionalsDto> Professionals { get; set; }

    }
}
