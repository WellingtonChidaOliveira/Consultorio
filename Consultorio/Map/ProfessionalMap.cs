using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Map
{
    public class ProfessionalMap : BaseMap<Professional>
    {
        public ProfessionalMap() : base("yb_professional")
        {
        }
        public override void Configure(EntityTypeBuilder<Professional> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Active).HasColumnName("Active");

            builder.HasMany(x => x.Specialties).WithMany(x => x.Professionals)
                .UsingEntity<ProfessionalSpecialty>(
                x => x.HasOne(p => p.Specialty).WithMany().HasForeignKey(x => x.SpecialtyId),
                x => x.HasOne(p => p.Professional).WithMany().HasForeignKey(x => x.ProfessionalId),
                x =>
                {
                    x.ToTable("tb_professional_speciality");
                    x.HasKey(p => new { p.SpecialtyId, p.ProfessionalId });
                    x.Property(p => p.SpecialtyId).HasColumnName("id_speciality").IsRequired();
                    x.Property(p => p.ProfessionalId).HasColumnName("id_professional").IsRequired();
                }
                );

        }
    }
}
