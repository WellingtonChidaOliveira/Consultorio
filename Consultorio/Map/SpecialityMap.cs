using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Map
{
    public class SpecialityMap : BaseMap<Speciality>
    {
        public SpecialityMap() : base("tb_speciality")
        {
        }
        public override void Configure(EntityTypeBuilder<Speciality> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.Active).HasColumnName("active");
        }
    }
}
