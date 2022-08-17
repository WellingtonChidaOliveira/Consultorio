using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Map
{
    public class AppointmentMap : BaseMap<Appointment>
    {
        public AppointmentMap() : base("tb_appointment") { }
        public override void Configure(EntityTypeBuilder<Appointment> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Status).HasColumnName("status").HasDefaultValue(1);
            builder.Property(x => x.Price).HasPrecision(7, 2).HasColumnName("price");
            builder.Property(x => x.DateHour).HasColumnName("date").IsRequired();

            builder.Property(x => x.PatientId).HasColumnName("id_patient").IsRequired();
            builder.HasOne(x => x.Patient).WithMany(x => x.Appointments).HasForeignKey(x => x.PatientId);

            builder.Property(x => x.ProfessionalId).HasColumnName("id_professional").IsRequired();
            builder.HasOne(x => x.Professional).WithMany(x => x.Appointments).HasForeignKey(x => x.ProfessionalId);

            builder.Property(x => x.SpecialityId).HasColumnName("id_speciality").IsRequired();
            builder.HasOne(x => x.Speciality).WithMany(x => x.Appointments).HasForeignKey(x => x.SpecialityId);

        }
    }
}
