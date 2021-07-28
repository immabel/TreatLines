using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines_v1.DAL.Entities;

namespace TreatLines_v1.DAL.Configurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescriptions").HasKey(k => k.Id);
            builder.Property(p => p.Description);
            builder
                .HasMany(m => m.Appointments)
                .WithOne(o => o.Prescription)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
