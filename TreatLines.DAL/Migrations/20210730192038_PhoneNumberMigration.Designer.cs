﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TreatLines.DAL;

namespace TreatLines.DAL.Migrations
{
    [DbContext(typeof(TLinesDbContext))]
    [Migration("20210730192038_PhoneNumberMigration")]
    partial class PhoneNumberMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                            ConcurrencyStamp = "3b2c58e5-8450-4686-ab4e-f52d65a4c9c6",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                            ConcurrencyStamp = "b6cccb55-8e96-454d-8f8b-a0e3c3991bed",
                            Name = "HospitalAdmin",
                            NormalizedName = "HOSPITALADMIN"
                        },
                        new
                        {
                            Id = "828A3B02-77C0-45C1-8E97-6ED57711E577",
                            ConcurrencyStamp = "428f1d63-3fff-4dd4-a142-38d4bc4862d2",
                            Name = "Doctor",
                            NormalizedName = "DOCTOR"
                        },
                        new
                        {
                            Id = "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                            ConcurrencyStamp = "23185139-5cd4-432e-9156-cfee62a1fa0d",
                            Name = "Patient",
                            NormalizedName = "PATIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "00CA41A9-C962-4230-937E-D5F54772C062",
                            RoleId = "2AEFE1C5-C5F0-4399-8FB8-420813567554"
                        },
                        new
                        {
                            UserId = "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                            RoleId = "99DA7670-5471-414F-834E-9B3A6B6C8F6F"
                        },
                        new
                        {
                            UserId = "E8D13331-62AB-463E-A283-6493B68A3622",
                            RoleId = "828A3B02-77C0-45C1-8E97-6ED57711E577"
                        },
                        new
                        {
                            UserId = "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                            RoleId = "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Canceled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("DateTimeAppointment")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("PrescriptionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Doctor", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Experience")
                        .HasColumnType("float");

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<bool>("OnHoliday")
                        .HasColumnType("bit");

                    b.Property<string>("Position")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("HospitalId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            UserId = "E8D13331-62AB-463E-A283-6493B68A3622",
                            Experience = 6.0,
                            HospitalId = 1,
                            OnHoliday = false,
                            Position = "cosmetologist",
                            Price = 400m,
                            ScheduleId = 1
                        });
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.DoctorPatient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("DoctorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId")
                        .IsUnique();

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("DoctorPatient");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Hospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTimeOffset>("CreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("RegisterDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Type")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Hospitals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Petrovna Ave. 2",
                            City = "Kharkiv",
                            Country = "Ukraine",
                            CreationDate = new DateTimeOffset(new DateTime(2017, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)),
                            Name = "SeventhSeason",
                            Rating = 4.0999999999999996,
                            RegisterDateTime = new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            Type = "common"
                        });
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.HospitalAdmin", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("HospitalId");

                    b.ToTable("HospitalsAdmins");

                    b.HasData(
                        new
                        {
                            UserId = "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                            HospitalId = 1
                        });
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Patient", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BloodType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            UserId = "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                            BloodType = "0",
                            Discount = 5.0,
                            HospitalId = 1,
                            Sex = "Male"
                        });
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.RequestToCreateHospital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("DateOfRequestCreation")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("HospitalCreationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmitterFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmitterLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RequestsToCreateHospital");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.RequestToCreatePatient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BloodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("DateOfRequestCreation")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RequestsToCreatePatient");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("EndTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("StartTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("WorkDays")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndTime = new DateTimeOffset(new DateTime(2021, 7, 30, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            StartTime = new DateTimeOffset(new DateTime(2021, 7, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            WorkDays = "01234"
                        });
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Blocked")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("RegisterDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "00CA41A9-C962-4230-937E-D5F54772C062",
                            AccessFailedCount = 0,
                            Blocked = false,
                            ConcurrencyStamp = "cc318381-fb0d-4500-aee2-e07f6e3c5418",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Adminovich",
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEPoGovEUk07F3AE206TEEB6mEPlNQQGcemx2cKLR4A7Mpate/FnOYdBB9R9+YkMk8w==",
                            PhoneNumber = "+38(050)245-32-52",
                            PhoneNumberConfirmed = false,
                            RegisterDateTime = new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            SecurityStamp = "55b75e4d-3d6c-498c-88de-d538d6c7b1bb",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                            AccessFailedCount = 0,
                            Blocked = false,
                            ConcurrencyStamp = "e646260c-4902-4988-a09a-6cd11f36887a",
                            Email = "ssadmin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Katya",
                            LastName = "Zamolodchikova",
                            LockoutEnabled = false,
                            NormalizedEmail = "ssadmin@gmail.com",
                            NormalizedUserName = "ssadmin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAECl82Gb/XQfSoD1sRisRQ/kl6fF6JvfM0MTmjVNXLYBtW5/Prpl1UuzUdY1/7dalJA==",
                            PhoneNumber = "+38(096)498-65-82",
                            PhoneNumberConfirmed = false,
                            RegisterDateTime = new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            SecurityStamp = "179065fe-f6f9-43ef-b608-8be48e19f908",
                            TwoFactorEnabled = false,
                            UserName = "ssadmin@gmail.com"
                        },
                        new
                        {
                            Id = "E8D13331-62AB-463E-A283-6493B68A3622",
                            AccessFailedCount = 0,
                            Blocked = false,
                            ConcurrencyStamp = "ad1e1dfc-d80d-4099-85d9-6a13e49d5697",
                            Email = "alaska.thunderfuck@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Alaska",
                            LastName = "Thunderfuck",
                            LockoutEnabled = false,
                            NormalizedEmail = "alaska.thunderfuck@gmail.com",
                            NormalizedUserName = "alaska.thunderfuck@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEJT35VZZthwFjuifYiRXg2axnj3jXbpGocRL2LJE7lgf7jz1m3tt72xB6UFucX1bGA==",
                            PhoneNumber = "+38(096)336-65-27",
                            PhoneNumberConfirmed = false,
                            RegisterDateTime = new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            SecurityStamp = "dd9668bb-dfe9-4602-ae3c-e23236640053",
                            TwoFactorEnabled = false,
                            UserName = "alaska.thunderfuck@gmail.com"
                        },
                        new
                        {
                            Id = "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                            AccessFailedCount = 0,
                            Blocked = false,
                            ConcurrencyStamp = "a66eca59-c929-4179-8072-71b14f2930e9",
                            Email = "de.tox@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "De",
                            LastName = "Tox",
                            LockoutEnabled = false,
                            NormalizedEmail = "de.tox@gmail.com",
                            NormalizedUserName = "de.tox@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEJDJtgZGF8RvrTBu33Iid0NOoMhzMhi2NZHjK6uv3T7tU37DjdmGz0KhE0k0cHZaiQ==",
                            PhoneNumber = "+38(096)838-36-82",
                            PhoneNumberConfirmed = false,
                            RegisterDateTime = new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)),
                            SecurityStamp = "53eea78f-97cd-492b-920e-23bfb3b7853e",
                            TwoFactorEnabled = false,
                            UserName = "de.tox@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TreatLines.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TreatLines.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TreatLines.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TreatLines.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Appointment", b =>
                {
                    b.HasOne("TreatLines.DAL.Entities.Prescription", "Prescription")
                        .WithMany("Appointments")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Doctor", b =>
                {
                    b.HasOne("TreatLines.DAL.Entities.Hospital", "Hospital")
                        .WithMany("Doctors")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TreatLines.DAL.Entities.Schedule", "Schedule")
                        .WithMany("Doctors")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("TreatLines.DAL.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("TreatLines.DAL.Entities.Doctor", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");

                    b.Navigation("Schedule");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.DoctorPatient", b =>
                {
                    b.HasOne("TreatLines.DAL.Entities.Appointment", "Appointment")
                        .WithOne()
                        .HasForeignKey("TreatLines.DAL.Entities.DoctorPatient", "AppointmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TreatLines.DAL.Entities.Doctor", "Doctor")
                        .WithMany("DoctorPatients")
                        .HasForeignKey("DoctorId");

                    b.HasOne("TreatLines.DAL.Entities.Patient", "Patient")
                        .WithMany("PatientDoctors")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Appointment");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.HospitalAdmin", b =>
                {
                    b.HasOne("TreatLines.DAL.Entities.Hospital", "Hospital")
                        .WithMany("HospitalAdmins")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TreatLines.DAL.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("TreatLines.DAL.Entities.HospitalAdmin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Patient", b =>
                {
                    b.HasOne("TreatLines.DAL.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("TreatLines.DAL.Entities.Patient", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Doctor", b =>
                {
                    b.Navigation("DoctorPatients");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Hospital", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("HospitalAdmins");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Patient", b =>
                {
                    b.Navigation("PatientDoctors");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Prescription", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("TreatLines.DAL.Entities.Schedule", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
