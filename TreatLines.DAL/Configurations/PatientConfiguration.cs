using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines.DAL.Entities;

namespace TreatLines.DAL.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patients").HasKey(k => k.UserId);
            builder.Property(p => p.BloodType).HasMaxLength(30);
            builder.Property(p => p.Sex).HasMaxLength(30);
            builder.Property(p => p.Discount);
            //builder.Property(p => p.HospitalRating);
            builder.Property(p => p.HospitalId);
            builder.Property(p => p.DateOfBirth);
            builder
                .HasOne(h => h.User)
                .WithOne();
            builder
                .HasMany(h => h.PatientDoctors)
                .WithOne(o => o.Patient);
        }
    }
}
