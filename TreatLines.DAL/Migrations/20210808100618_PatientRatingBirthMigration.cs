using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreatLines.DAL.Migrations
{
    public partial class PatientRatingBirthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "RequestsToCreatePatient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BloodType",
                table: "RequestsToCreatePatient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateOfBirth",
                table: "RequestsToCreatePatient",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<double>(
                name: "HospitalRating",
                table: "Patients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2AEFE1C5-C5F0-4399-8FB8-420813567554", "5d74b82b-4f16-492d-aceb-b31193630eab", "Admin", "ADMIN" },
                    { "99DA7670-5471-414F-834E-9B3A6B6C8F6F", "71abfaf0-04ca-4cd5-b29f-ee853ead8232", "HospitalAdmin", "HOSPITALADMIN" },
                    { "828A3B02-77C0-45C1-8E97-6ED57711E577", "97dcfce5-0ba5-4743-9a0c-0e21caa032b4", "Doctor", "DOCTOR" },
                    { "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C", "f04f0970-a79b-45a7-aaa5-91bd3564adfa", "Patient", "PATIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Blocked", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00CA41A9-C962-4230-937E-D5F54772C062", 0, false, "c2cb4c54-3786-42d3-b34a-1f4e2ee72baf", "admin@gmail.com", false, "Admin", "Adminovich", false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEARI4pJ8S5FLHJUh+frJHJRF1JW8QbGo6EDCCzFaWzkZAsrEs6TU+WEy+qMsqSLusA==", "+38(050)245-32-52", false, new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "2b6abf80-6b79-48a1-aa08-4d049b262b19", false, "admin@gmail.com" },
                    { "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09", 0, false, "1ea719e1-9205-40cc-9271-7a3e620f6e75", "ssadmin@gmail.com", false, "Katya", "Zamolodchikova", false, null, "ssadmin@gmail.com", "ssadmin@gmail.com", "AQAAAAEAACcQAAAAEFabvEpNBVNxyk8tom/5oc22a5z+STmZsilhs65DDLwOtgKJ7yRQIrXnKWOxpBcaJg==", "+38(096)498-65-82", false, new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "4cdb4ced-71e6-4b5c-947d-45a138c43c71", false, "ssadmin@gmail.com" },
                    { "E8D13331-62AB-463E-A283-6493B68A3622", 0, false, "9afd200e-873d-43a4-9527-5b2d036bd687", "alaska.thunderfuck@gmail.com", false, "Alaska", "Thunderfuck", false, null, "alaska.thunderfuck@gmail.com", "alaska.thunderfuck@gmail.com", "AQAAAAEAACcQAAAAEHp9/z0/zfObMgpEVAtT0UKs/n+6wCSG5yvgVt1ebPFVv6PPxFfMbREytCgMD2lI+Q==", "+38(096)336-65-27", false, new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "d5caf907-040b-4f46-ab40-8cc2e65c93c0", false, "alaska.thunderfuck@gmail.com" },
                    { "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B", 0, false, "33f84c1c-54fa-4f15-8dcc-93004bf23baa", "de.tox@gmail.com", false, "De", "Tox", false, null, "de.tox@gmail.com", "de.tox@gmail.com", "AQAAAAEAACcQAAAAELps5bMLE7DDKoOjsiP2aDCUXSwZOFc/QmlqmHA+V2NgtrJWC2OaCVfdya8lEi4I3A==", "+38(096)838-36-82", false, new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "6ca9d7da-f29a-4ede-8303-cc43a9433f6c", false, "de.tox@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "Blocked", "City", "Country", "CreationDate", "Name", "Rating", "RegisterDateTime", "Type" },
                values: new object[] { 1, "Petrovna Ave. 2", false, "Kharkiv", "Ukraine", new DateTimeOffset(new DateTime(2017, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), "SeventhSeason", 4.0999999999999996, new DateTimeOffset(new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "common" });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "EndTime", "StartTime", "WorkDays" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2021, 8, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "01234" });

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
                columns: new[] { "UserId", "DateOfBirth", "Education", "Experience", "HospitalId", "OnHoliday", "Position", "Price", "ScheduleId", "Sex" },
                values: new object[] { "E8D13331-62AB-463E-A283-6493B68A3622", new DateTimeOffset(new DateTime(1970, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), null, "Worked at \"Health main\"", 1, false, "cosmetologist", 400m, 1, null });

            migrationBuilder.InsertData(
                table: "HospitalsAdmins",
                columns: new[] { "UserId", "HospitalId" },
                values: new object[] { "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09", 1 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "UserId", "BloodType", "DateOfBirth", "Discount", "HospitalId", "HospitalRating", "Sex" },
                values: new object[] { "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B", "O-", new DateTimeOffset(new DateTime(1990, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0)), 5.0, 1, 0.0, "Male" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "RequestsToCreatePatient");

            migrationBuilder.DropColumn(
                name: "HospitalRating",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "RequestsToCreatePatient",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BloodType",
                table: "RequestsToCreatePatient",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
