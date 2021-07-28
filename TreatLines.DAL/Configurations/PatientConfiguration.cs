using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines_v1.DAL.Entities;

namespace TreatLines_v1.DAL.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients").HasKey(k => k.UserId);
            builder.Property(p => p.BloodType).HasMaxLength(100);
            builder.Property(p => p.Sex).HasMaxLength(30);
            builder.Property(p => p.HospitalId);
            builder
                .HasOne(h => h.User)
                .WithOne();
            builder
                .HasMany(h => h.PatientDoctors)
                .WithOne(o => o.Patient);
        }
    }
}
