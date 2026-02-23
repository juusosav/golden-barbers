using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionIdInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Barbers",
                newName: "PositionName");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Barbers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                column: "PositionId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                columns: new[] { "PositionId", "PositionName" },
                values: new object[] { 2, "Junior Barber" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                columns: new[] { "PositionId", "PositionName" },
                values: new object[] { 2, "Junior Barber" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                columns: new[] { "PositionId", "PositionName" },
                values: new object[] { 1, "Senior Barber" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"),
                column: "PositionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                columns: new[] { "PositionId", "PositionName" },
                values: new object[] { 1, "Senior Barber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Barbers");

            migrationBuilder.RenameColumn(
                name: "PositionName",
                table: "Barbers",
                newName: "Position");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                column: "Position",
                value: "Creative Barber");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                column: "Position",
                value: "Precision barber");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                column: "Position",
                value: "Master Barber");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                column: "Position",
                value: "Style Specialist");
        }
    }
}
