using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines_v1.DAL.Entities;

namespace TreatLines_v1.DAL.Configurations
{
    public class HospitalAdminConfiguration : IEntityTypeConfiguration<HospitalAdmin>
    {
        public void Configure(EntityTypeBuilder<HospitalAdmin> builder)
        {
            builder.ToTable("HospitalsAdmins").HasKey(p => p.UserId);
            builder
                .HasOne(u => u.User)
                .WithOne();
            builder
                .HasOne(h => h.Hospital)
                .WithMany(a => a.HospitalAdmins);
        }
    }
}
