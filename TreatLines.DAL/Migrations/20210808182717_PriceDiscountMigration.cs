using Microsoft.EntityFrameworkCore.Migrations;

namespace TreatLines.DAL.Migrations
{
    public partial class PriceDiscountMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceWithDiscount",
                table: "Appointments",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "a437b472-918b-4d4f-a9e6-74c387f9d695");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "e1fe3d6a-169d-4807-b391-d5c6157fd025");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "273c3364-f48b-4186-8f35-13f1af227658");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "6bd16b3a-8691-417b-9ba1-75899661cfe5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e10d685-06e7-4cfc-a9a0-20e02ab9a51c", "AQAAAAEAACcQAAAAEF3E/DpYOUYkGpVLUCWRCx1fjbzzeNu0ALMLHNgfEjFZYOsum1TMyb6jlrqtCts/Ow==", "83039c6a-9651-41a6-b994-15764257b353" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c15b268-dec7-4b3f-9645-3b8c66cc16e3", "AQAAAAEAACcQAAAAEO3avHm14N2fdreHrk/HVXPQPAeni/8+1X77D5yYVZZ6rGdIdeDPFfqM+EyWIQOiig==", "f499094e-d90a-48c6-a746-a0546c4eed32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06b4e351-5e31-4d5c-9754-158c3a782d1a", "AQAAAAEAACcQAAAAEOjgg81MYY002tDat7HeEc2KLYwgsg86yV2KHnu1Zubp69LZ7pDsdf4OSCVa6rwtsQ==", "88646c31-6bcc-4280-b65f-5c1e9449f3e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a3cfe8d-0b6b-4f72-ab1f-bfb6ceacfd4b", "AQAAAAEAACcQAAAAEELPjlqvKXP8wbXKDdhfFGdPjrYhPPhnhASGX6J4Otlm+bc6nrXR1UoIkRrNr/mWQA==", "980569ae-0b5a-4d8e-b706-c4e39bd3626d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceWithDiscount",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                column: "ConcurrencyStamp",
                value: "5d74b82b-4f16-492d-aceb-b31193630eab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                column: "ConcurrencyStamp",
                value: "f04f0970-a79b-45a7-aaa5-91bd3564adfa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828A3B02-77C0-45C1-8E97-6ED57711E577",
                column: "ConcurrencyStamp",
                value: "97dcfce5-0ba5-4743-9a0c-0e21caa032b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                column: "ConcurrencyStamp",
                value: "71abfaf0-04ca-4cd5-b29f-ee853ead8232");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00CA41A9-C962-4230-937E-D5F54772C062",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2cb4c54-3786-42d3-b34a-1f4e2ee72baf", "AQAAAAEAACcQAAAAEARI4pJ8S5FLHJUh+frJHJRF1JW8QbGo6EDCCzFaWzkZAsrEs6TU+WEy+qMsqSLusA==", "2b6abf80-6b79-48a1-aa08-4d049b262b19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ea719e1-9205-40cc-9271-7a3e620f6e75", "AQAAAAEAACcQAAAAEFabvEpNBVNxyk8tom/5oc22a5z+STmZsilhs65DDLwOtgKJ7yRQIrXnKWOxpBcaJg==", "4cdb4ced-71e6-4b5c-947d-45a138c43c71" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33f84c1c-54fa-4f15-8dcc-93004bf23baa", "AQAAAAEAACcQAAAAELps5bMLE7DDKoOjsiP2aDCUXSwZOFc/QmlqmHA+V2NgtrJWC2OaCVfdya8lEi4I3A==", "6ca9d7da-f29a-4ede-8303-cc43a9433f6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "E8D13331-62AB-463E-A283-6493B68A3622",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9afd200e-873d-43a4-9527-5b2d036bd687", "AQAAAAEAACcQAAAAEHp9/z0/zfObMgpEVAtT0UKs/n+6wCSG5yvgVt1ebPFVv6PPxFfMbREytCgMD2lI+Q==", "d5caf907-040b-4f46-ab40-8cc2e65c93c0" });
        }
    }
}
