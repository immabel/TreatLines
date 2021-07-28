using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines.DAL.Entities;

namespace TreatLines.DAL.Configurations
{
    public class RequestToCreateHospitalConfiguration : IEntityTypeConfiguration<RequestToCreateHospital>
    {
        public void Configure(EntityTypeBuilder<RequestToCreateHospital> builder)
        {
            builder.ToTable("RequestsToCreate").HasKey(k => k.Id);
            builder.Property(p => p.HospitalName).IsRequired(); ;
            builder.Property(p => p.SubmitterFirstName).IsRequired();
            builder.Property(p => p.SubmitterLastName).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Address).IsRequired();
            builder.Property(p => p.Country).IsRequired();
            builder.Property(p => p.DateOfRequestCreation).IsRequired();
        }
    }
}
