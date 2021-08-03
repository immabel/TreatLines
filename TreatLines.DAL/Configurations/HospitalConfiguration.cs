using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines.DAL.Entities;

namespace TreatLines.DAL.Configurations
{
    public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.ToTable("Hospitals").HasKey(k => k.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Address).HasMaxLength(100);
            builder.Property(p => p.City).HasMaxLength(100);
            builder.Property(p => p.Country).HasMaxLength(100);
            builder.Property(p => p.Rating);
            builder.Property(p => p.RegisterDateTime).IsRequired();
            builder.Property(p => p.CreationDate).IsRequired();
            builder.Property(p => p.Type).HasMaxLength(30);
            builder.Property(u => u.Blocked);
            builder
                .HasMany(h => h.Doctors)
                .WithOne(o => o.Hospital);
            builder
                .HasMany(h => h.HospitalAdmins)
                .WithOne(o => o.Hospital);
        }
    }
}
