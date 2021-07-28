using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TreatLines.DAL.Entities;
using TreatLines.DAL.Extentions;

namespace TreatLines.DAL
{
    public class TLinesDbContext : IdentityDbContext<User>
    {
        public TLinesDbContext(DbContextOptions<TLinesDbContext> options)
            : base(options)
        { }
        public DbSet<HospitalAdmin> HospitalAdmins { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        public DbSet<RequestToCreateHospital> RequestsToCreateHospital { get; set; }
        public DbSet<RequestToCreatePatient> RequestsToCreatePatient { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalAdminConfiguration());
            modelBuilder.ApplyConfiguration(new HospitalConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorPatientConfiguration());
            modelBuilder.ApplyConfiguration(new RequestToCreateHospitalConfiguration());
            modelBuilder.ApplyConfiguration(new RequestToCreateDoctorConfiguration());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
