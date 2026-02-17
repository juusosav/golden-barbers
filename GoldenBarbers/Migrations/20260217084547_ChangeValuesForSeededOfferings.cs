using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class ChangeValuesForSeededOfferings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                column: "TraineePrice",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                column: "SeniorPrice",
                value: 28);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                column: "TraineePrice",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                column: "SeniorPrice",
                value: 30);
        }
    }
}
