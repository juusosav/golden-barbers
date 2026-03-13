using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminBarberDtoAndUpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonalAddress",
                table: "Barbers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalEmail",
                table: "Barbers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalPhone",
                table: "Barbers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Barbers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Barbers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                columns: new[] { "PersonalAddress", "PersonalEmail", "PersonalPhone", "Salary", "StartDate" },
                values: new object[] { "52 Victoria Road, London", "stevie_robs@gmail.com", "077 5627 5582", 2020.3m, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                columns: new[] { "PersonalAddress", "PersonalEmail", "PersonalPhone", "Salary", "StartDate" },
                values: new object[] { "21 Manor Road, London", "hannah.law@gmail.com", "070 6859 4772", 2290.5m, new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                columns: new[] { "PersonalAddress", "PersonalEmail", "PersonalPhone", "Salary", "StartDate" },
                values: new object[] { "52 Cassland Road, London", "sarahlee@hotmail.com", "078 7592 3593", 2350.8m, new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                columns: new[] { "PersonalAddress", "PersonalEmail", "PersonalPhone", "Salary", "StartDate" },
                values: new object[] { "24 Lionsdale Ave, London", "charliejack@gmail.com", "070 4871 9510", 2450.4m, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"),
                columns: new[] { "PersonalAddress", "PersonalEmail", "PersonalPhone", "Salary", "StartDate" },
                values: new object[] { "51 Church Lane, London", "john.s3@gmail.com", "079 4318 8088", 2670.9m, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                columns: new[] { "PersonalAddress", "PersonalEmail", "PersonalPhone", "Salary", "StartDate" },
                values: new object[] { "66 Station Road, London", "rebeccaa12@gmail.com", "078 1834 6640", 2530.7m, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalAddress",
                table: "Barbers");

            migrationBuilder.DropColumn(
                name: "PersonalEmail",
                table: "Barbers");

            migrationBuilder.DropColumn(
                name: "PersonalPhone",
                table: "Barbers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Barbers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Barbers");
        }
    }
}
