using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines.DAL.Entities;

namespace TreatLines.DAL.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.ToTable("Appointments").HasKey(k => k.Id);
            builder.Property(p => p.DateTimeAppointment);
            builder.Property(p => p.Price).HasColumnType("money");
            builder.Property(p => p.Canceled);
            builder
                .HasOne(h => h.Prescription)
                .WithMany(m => m.Appointments)
                .IsRequired(false);
        }
    }
}
