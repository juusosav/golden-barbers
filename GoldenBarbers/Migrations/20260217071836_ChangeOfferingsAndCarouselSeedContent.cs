using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOfferingsAndCarouselSeedContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Offerings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("14c09ff8-c38f-4d7e-9e27-7e498f4a446d"),
                column: "Name",
                value: "Haircuts & Styling");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                columns: new[] { "Description", "JuniorPrice", "Name", "SeniorPrice", "TraineePrice" },
                values: new object[] { "The old-school treatment for a dutch beard style including finishing beard treatment with oils.", 30, "Dutch Beard Treatment", 35, 25 });

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("39cb2981-ab90-4971-a4aa-f22d5a7b0a9f"),
                column: "Description",
                value: "Classic professional barber haircut.");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"),
                columns: new[] { "Description", "JuniorPrice", "Name", "SeniorPrice", "TraineePrice" },
                values: new object[] { "Haircut with a complete beard treatment package including steaming and grooming", 45, "Haircut & Beard Treatment", 50, 37 });

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                columns: new[] { "Description", "JuniorPrice", "Name", "SeniorPrice", "TraineePrice" },
                values: new object[] { "Classic american beard trimming with razorblade and foaming.", 25, "American Beard Trim", 30, 22 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Offerings");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("14c09ff8-c38f-4d7e-9e27-7e498f4a446d"),
                column: "Name",
                value: "Haircuts");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                columns: new[] { "JuniorPrice", "Name", "SeniorPrice", "TraineePrice" },
                values: new object[] { 118, "Long Hair Coloring with Haircut", 130, 100 });

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"),
                columns: new[] { "JuniorPrice", "Name", "SeniorPrice", "TraineePrice" },
                values: new object[] { 90, "Short Hair Coloring and Haircut", 100, 75 });

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                columns: new[] { "JuniorPrice", "Name", "SeniorPrice", "TraineePrice" },
                values: new object[] { 58, "Party Hairstyling with Haircut", 70, 50 });
        }
    }
}
