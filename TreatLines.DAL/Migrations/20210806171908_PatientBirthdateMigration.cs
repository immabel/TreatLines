using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreatLines.DAL.Migrations
{
    public partial class PatientBirthdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2AEFE1C5-C5F0-4399-8FB8-420813567554", "00CA41A9-C962-4230-937E-D5F54772C062" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "99DA7670-5471-414F-834E-9B3A6B6C8F6F", "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C", "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "828A3B02-77C0-45C1-8E97-6ED57711E577", "E8D13331-62AB-463E-A283-6493B68A3622" });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "UserId",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622");

            migrationBuilder.DeleteData(
                table: "HospitalsAdmins",
                keyColumn: "UserId",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09");

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "UserId",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622");

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "HospitalId",
                table: "RequestsToCreatePatient",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "RequestsToCreatePatient",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2AEFE1C5-C5F0-4399-8FB8-420813567554", "547f0eb2-73ea-4fea-87c2-3585ead2a311", "Admin", "ADMIN" },
                    { "99DA7670-5471-414F-834E-9B3A6B6C8F6F", "a40fc831-0929-44c0-856e-71ee83636fca", "HospitalAdmin", "HOSPITALADMIN" },
                    { "828A3B02-77C0-45C1-8E97-6ED57711E577", "c0597454-a0f0-4708-a743-0a7ea91cb465", "Doctor", "DOCTOR" },
                    { "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C", "bd070f02-731b-412d-b235-bdd641ce1124", "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Blocked", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegisterDateTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00CA41A9-C962-4230-937E-D5F54772C062", 0, false, "bc8b56b2-e3ea-4826-920a-aa82501a2403", "admin@gmail.com", false, "Admin", "Adminovich", false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEOLhRGBX6cnnMHI1a0brqA8Dry1KerkN3XKM0tlFid8e6U8gK/sE5oPmC54iqkjv+A==", "+38(050)245-32-52", false, new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "b430bb88-cb45-4946-ac0a-f2bd4ca1fc39", false, "admin@gmail.com" },
                    { "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09", 0, false, "28aafff7-8956-4326-928d-4b9eb62307c1", "ssadmin@gmail.com", false, "Katya", "Zamolodchikova", false, null, "ssadmin@gmail.com", "ssadmin@gmail.com", "AQAAAAEAACcQAAAAELmNhElizbggBQ12XRpYnFHWzTm7D1GyF0/k4IyS+clmm7fFi3B6p2xMTUlLerWEyg==", "+38(096)498-65-82", false, new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "d35a0f2d-ecec-4e80-8f94-8bd58c718b60", false, "ssadmin@gmail.com" },
                    { "E8D13331-62AB-463E-A283-6493B68A3622", 0, false, "3513a4a1-e6ec-44f3-96d5-43a47a449eae", "alaska.thunderfuck@gmail.com", false, "Alaska", "Thunderfuck", false, null, "alaska.thunderfuck@gmail.com", "alaska.thunderfuck@gmail.com", "AQAAAAEAACcQAAAAENm/7teCQasQG7VH2Jo0CqYw1vrIxRfv2G/z7BmzJzlu8DA3q+sTKY7+0qS1gcG7Mw==", "+38(096)336-65-27", false, new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "b940aa86-4a23-48e5-b822-3e2a8f9adaf8", false, "alaska.thunderfuck@gmail.com" },
                    { "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B", 0, false, "03353ed2-e903-404e-9e92-f241e0defb7a", "de.tox@gmail.com", false, "De", "Tox", false, null, "de.tox@gmail.com", "de.tox@gmail.com", "AQAAAAEAACcQAAAAENLEJLrL2l2EYJmeOGm7i+P3+xxu5fJSkjKUmjqPPHfOajqk8syAeTPshXO5n2rArQ==", "+38(096)838-36-82", false, new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "f3ea3b64-781a-4839-a40f-8c01b762442e", false, "de.tox@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "Blocked", "City", "Country", "CreationDate", "Name", "Rating", "RegisterDateTime", "Type" },
                values: new object[] { 1, "Petrovna Ave. 2", false, "Kharkiv", "Ukraine", new DateTimeOffset(new DateTime(2017, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "SeventhSeason", 4.0999999999999996, new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "common" });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "EndTime", "StartTime", "WorkDays" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2021, 8, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "01234" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2AEFE1C5-C5F0-4399-8FB8-420813567554", "00CA41A9-C962-4230-937E-D5F54772C062" },
                    { "99DA7670-5471-414F-834E-9B3A6B6C8F6F", "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09" },
                    { "828A3B02-77C0-45C1-8E97-6ED57711E577", "E8D13331-62AB-463E-A283-6493B68A3622" },
                    { "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C", "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "UserId", "Education", "Experience", "HospitalId", "OnHoliday", "Position", "Price", "ScheduleId" },
                values: new object[] { "E8D13331-62AB-463E-A283-6493B68A3622", null, "Worked at \"Health main\"", 1, false, "cosmetologist", 400m, 1 });

            migrationBuilder.InsertData(
                table: "HospitalsAdmins",
                columns: new[] { "UserId", "HospitalId" },
                values: new object[] { "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09", 1 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "UserId", "BloodType", "Discount", "HospitalId", "Sex" },
                values: new object[] { "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B", "0", 5.0, 1, "Male" });
        }
    }
}
