using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAdminBarberSalaryToDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER TABLE ""Barbers"" ALTER COLUMN ""Salary"" TYPE numeric 
          USING ""Salary""::numeric"
            );

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                column: "Salary",
                value: 2020.3m);

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                column: "Salary",
                value: 2290.5m);

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                column: "Salary",
                value: 2350.8m);

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                column: "Salary",
                value: 2450.4m);

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"),
                column: "Salary",
                value: 2670.9m);

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                column: "Salary",
                value: 2530.7m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER TABLE ""Barbers"" ALTER COLUMN ""Salary"" TYPE text 
          USING ""Salary""::text"
            );

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                column: "Salary",
                value: "2020.3");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                column: "Salary",
                value: "2290.5");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                column: "Salary",
                value: "2350.8");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                column: "Salary",
                value: "2450.4");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"),
                column: "Salary",
                value: "2670.9");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                column: "Salary",
                value: "2530.7");
        }
    }
}
