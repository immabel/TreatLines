using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines_v1.DAL.Entities;

namespace TreatLines_v1.DAL.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules").HasKey(k => k.Id);
            builder.Property(p => p.StartTime);
            builder.Property(p => p.EndTime);
            builder.Property(p => p.WorkDays).HasMaxLength(10);
            builder
                .HasMany(h => h.Doctors)
                .WithOne(o => o.Schedule)
                .IsRequired(false);
        }
    }
}
