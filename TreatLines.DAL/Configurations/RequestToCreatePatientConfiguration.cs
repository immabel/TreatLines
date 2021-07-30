using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TreatLines.DAL.Entities;

namespace TreatLines.DAL.Configurations
{
    public class RequestToCreatePatientConfiguration : IEntityTypeConfiguration<RequestToCreatePatient>
    {
        public void Configure(EntityTypeBuilder<RequestToCreatePatient> builder)
        {
            builder.ToTable("RequestsToCreatePatient").HasKey(k => k.Id);
            builder.Property(p => p.HospitalId).IsRequired();
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.DateOfRequestCreation).IsRequired();
            builder.Property(p => p.PhoneNumber).IsRequired();
            builder.Property(p => p.BloodType);
            builder.Property(p => p.Sex);
        }
    }
}
