using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines.DAL.Entities;

namespace TreatLines.DAL.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors").HasKey(p => p.UserId);
            builder.Property(u => u.Position).HasMaxLength(30);
            builder.Property(u => u.OnHoliday);
            builder.Property(u => u.Education);
            builder.Property(u => u.Experience);
            builder.Property(u => u.Price).HasColumnType("money");
            builder.Property(p => p.Sex).HasMaxLength(30);
            builder.Property(p => p.DateOfBirth);
            builder
                .HasOne(h => h.User)
                .WithOne();
            builder
                .HasOne(h => h.Hospital)
                .WithMany(m => m.Doctors);
            builder
                .HasOne(h => h.Schedule)
                .WithMany(m => m.Doctors)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            builder
                .HasMany(h => h.DoctorPatients)
                .WithOne(o => o.Doctor);
        }
    }
}
