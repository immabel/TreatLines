using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines_v1.DAL.Entities;

namespace TreatLines_v1.DAL.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments").HasKey(k => k.Id);
            builder.Property(p => p.SkinType);
            builder.Property(p => p.SkinColor);
            builder.Property(p => p.PHlevel);
            builder.Property(p => p.Elasticity);
            builder.Property(p => p.DateTimeAppointment);
            builder.Property(p => p.LevelOfMoisture);
            builder.Property(p => p.Canceled);
            builder
                .HasOne(h => h.Prescription)
                .WithMany(m => m.Appointments)
                .IsRequired(false);
        }
    }
}
