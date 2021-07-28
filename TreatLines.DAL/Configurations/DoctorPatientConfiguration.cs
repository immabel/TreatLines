using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines_v1.DAL.Entities;

namespace TreatLines_v1.DAL.Configurations
{
    public class DoctorPatientConfiguration : IEntityTypeConfiguration<DoctorPatient>
    {
        public void Configure(EntityTypeBuilder<DoctorPatient> builder)
        {
            builder.ToTable("DoctorPatient").HasKey(k => k.Id);
            builder
                .HasOne(h => h.Patient)
                .WithMany(m => m.PatientDoctors)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(h => h.Doctor)
                .WithMany(m => m.DoctorPatients);
            builder
                .HasOne(h => h.Appointment)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(h => h.Dialog)
                .WithOne()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
