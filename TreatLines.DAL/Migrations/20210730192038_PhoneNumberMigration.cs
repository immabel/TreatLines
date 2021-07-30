using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreatLines.DAL.Migrations
{
    public partial class PhoneNumberMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestsToCreate",
                table: "RequestsToCreate");

            migrationBuilder.RenameTable(
                name: "RequestsToCreate",
                newName: "RequestsToCreatePatient");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "RequestsToCreateHospital",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "RequestsToCreatePatient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "RequestsToCreatePatient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "RequestsToCreatePatient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestsToCreatePatient",
                table: "RequestsToCreatePatient",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "3b2c58e5-8450-4686-ab4e-f52d65a4c9c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "23185139-5cd4-432e-9156-cfee62a1fa0d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "428f1d63-3fff-4dd4-a142-38d4bc4862d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "b6cccb55-8e96-454d-8f8b-a0e3c3991bed");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc318381-fb0d-4500-aee2-e07f6e3c5418", "AQAAAAEAACcQAAAAEPoGovEUk07F3AE206TEEB6mEPlNQQGcemx2cKLR4A7Mpate/FnOYdBB9R9+YkMk8w==", "55b75e4d-3d6c-498c-88de-d538d6c7b1bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e646260c-4902-4988-a09a-6cd11f36887a", "AQAAAAEAACcQAAAAECl82Gb/XQfSoD1sRisRQ/kl6fF6JvfM0MTmjVNXLYBtW5/Prpl1UuzUdY1/7dalJA==", "179065fe-f6f9-43ef-b608-8be48e19f908" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a66eca59-c929-4179-8072-71b14f2930e9", "AQAAAAEAACcQAAAAEJDJtgZGF8RvrTBu33Iid0NOoMhzMhi2NZHjK6uv3T7tU37DjdmGz0KhE0k0cHZaiQ==", "53eea78f-97cd-492b-920e-23bfb3b7853e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad1e1dfc-d80d-4099-85d9-6a13e49d5697", "AQAAAAEAACcQAAAAEJT35VZZthwFjuifYiRXg2axnj3jXbpGocRL2LJE7lgf7jz1m3tt72xB6UFucX1bGA==", "dd9668bb-dfe9-4602-ae3c-e23236640053" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 7, 30, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 7, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestsToCreatePatient",
                table: "RequestsToCreatePatient");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "RequestsToCreateHospital");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "RequestsToCreatePatient");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "RequestsToCreatePatient");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "RequestsToCreatePatient");

            migrationBuilder.RenameTable(
                name: "RequestsToCreatePatient",
                newName: "RequestsToCreate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestsToCreate",
                table: "RequestsToCreate",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "9bb7363d-b271-4945-9f8f-9dcff37cfffe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "16c4022c-8f6f-4063-8e32-e37877fcf1c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "cc69a410-21d7-4feb-bb4d-c4fc1c508f97");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "43dddbc4-45e3-40fd-84bf-816f0c491a4e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c8c0736-5cb2-4e20-9d72-ffa108e26185", "AQAAAAEAACcQAAAAEPmrW5XjJ+cjL41Lm6PTOLETlfBFigz1arEfxAtJqPZKFjWKQiy89AbQniWqeJ1EuQ==", "a7d24e27-3dad-4523-9fd7-561bd3b30524" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f777db2e-0e75-4480-815f-12140f789857", "AQAAAAEAACcQAAAAEF0TNxktam9PYrDceNpdvQH+HU2/CaxpZkyfTn36eqdE6q7VyY+ICJgFK61+ynvFKQ==", "531edc2e-83df-4016-bd67-56a8ad1c10cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07fa756d-476e-4e77-8923-432211775968", "AQAAAAEAACcQAAAAECRMyKvqvJ7eYxFGWg9+h1HiEU5zoGIlq5txgkrM07A1943RaYEq2d/RzBbbdYbQxw==", "5aaa2175-ad81-447a-a9a7-f90f63a6e116" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "903f2dc5-0c87-4f10-86d9-f55b3547368d", "AQAAAAEAACcQAAAAELva2ne267p2RO+UWhTALZlaN0BQE4AOfy2O499G+dRYYKtM3ym4jDFGsqCGha9UlQ==", "ccf97820-7be5-470f-88a4-8eace7d70490" });

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 7, 29, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 7, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
