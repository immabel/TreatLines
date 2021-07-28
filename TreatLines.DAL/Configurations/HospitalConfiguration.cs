using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines_v1.DAL.Entities;


namespace TreatLines_v1.DAL.Configurations
{
    public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.ToTable("Hospitals").HasKey(k => k.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Address).HasMaxLength(100);
            builder.Property(p => p.Country).HasMaxLength(100);
            builder
                .HasMany(h => h.Doctors)
                .WithOne(o => o.Hospital);
            builder
                .HasMany(h => h.HospitalAdmins)
                .WithOne(o => o.Hospital);
        }
    }
}
