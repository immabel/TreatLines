using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TreatLines.DAL.Migrations
{
    public partial class DoctorExperienceStrMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Blocked",
                table: "Hospitals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "547f0eb2-73ea-4fea-87c2-3585ead2a311");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "bd070f02-731b-412d-b235-bdd641ce1124");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "c0597454-a0f0-4708-a743-0a7ea91cb465");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "a40fc831-0929-44c0-856e-71ee83636fca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc8b56b2-e3ea-4826-920a-aa82501a2403", "AQAAAAEAACcQAAAAEOLhRGBX6cnnMHI1a0brqA8Dry1KerkN3XKM0tlFid8e6U8gK/sE5oPmC54iqkjv+A==", "b430bb88-cb45-4946-ac0a-f2bd4ca1fc39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28aafff7-8956-4326-928d-4b9eb62307c1", "AQAAAAEAACcQAAAAELmNhElizbggBQ12XRpYnFHWzTm7D1GyF0/k4IyS+clmm7fFi3B6p2xMTUlLerWEyg==", "d35a0f2d-ecec-4e80-8f94-8bd58c718b60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03353ed2-e903-404e-9e92-f241e0defb7a", "AQAAAAEAACcQAAAAENLEJLrL2l2EYJmeOGm7i+P3+xxu5fJSkjKUmjqPPHfOajqk8syAeTPshXO5n2rArQ==", "f3ea3b64-781a-4839-a40f-8c01b762442e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3513a4a1-e6ec-44f3-96d5-43a47a449eae", "AQAAAAEAACcQAAAAENm/7teCQasQG7VH2Jo0CqYw1vrIxRfv2G/z7BmzJzlu8DA3q+sTKY7+0qS1gcG7Mw==", "b940aa86-4a23-48e5-b822-3e2a8f9adaf8" });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "UserId",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                column: "Experience",
                value: "Worked at \"Health main\"");

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 8, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 8, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "Hospitals");

            migrationBuilder.AlterColumn<double>(
                name: "Experience",
                table: "Doctors",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                table: "Doctors",
                keyColumn: "UserId",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                column: "Experience",
                value: 6.0);

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 7, 30, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 7, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)) });
        }
    }
}
