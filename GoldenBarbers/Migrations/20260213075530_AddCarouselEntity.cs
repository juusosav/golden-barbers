using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class AddCarouselEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Offerings");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Offerings",
                newName: "TraineePrice");

            migrationBuilder.AddColumn<int>(
                name: "JuniorPrice",
                table: "Offerings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeniorPrice",
                table: "Offerings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppointmentOffering",
                columns: table => new
                {
                    AppointmentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    OfferingsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentOffering", x => new { x.AppointmentsId, x.OfferingsId });
                    table.ForeignKey(
                        name: "FK_AppointmentOffering_Appointments_AppointmentsId",
                        column: x => x.AppointmentsId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentOffering_Offerings_OfferingsId",
                        column: x => x.OfferingsId,
                        principalTable: "Offerings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarouselItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CarouselItems",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { new Guid("14c09ff8-c38f-4d7e-9e27-7e498f4a446d"), "/images/haircut_icon.png", "Barber Services" },
                    { new Guid("88f713d6-b493-4e7c-8df2-a9bbe28ef472"), "/images/hairstyle_icon.png", "Professional Hairstyling" },
                    { new Guid("dad920d2-466b-4459-95ea-94a16693d66b"), "/images/haircolor_icon.png", "Hair Coloring" }
                });

            migrationBuilder.InsertData(
                table: "Offerings",
                columns: new[] { "Id", "JuniorPrice", "Name", "SeniorPrice", "TraineePrice" },
                values: new object[,]
                {
                    { new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"), 118, "Long Hair Coloring with Haircut", 130, 100 },
                    { new Guid("39cb2981-ab90-4971-a4aa-f22d5a7b0a9f"), 30, "Barber Haircut", 38, 22 },
                    { new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"), 90, "Short Hair Coloring and Haircut", 100, 75 },
                    { new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"), 58, "Party Hairstyling with Haircut", 70, 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentOffering_OfferingsId",
                table: "AppointmentOffering",
                column: "OfferingsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentOffering");

            migrationBuilder.DropTable(
                name: "CarouselItems");

            migrationBuilder.DeleteData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"));

            migrationBuilder.DeleteData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("39cb2981-ab90-4971-a4aa-f22d5a7b0a9f"));

            migrationBuilder.DeleteData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"));

            migrationBuilder.DeleteData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"));

            migrationBuilder.DropColumn(
                name: "JuniorPrice",
                table: "Offerings");

            migrationBuilder.DropColumn(
                name: "SeniorPrice",
                table: "Offerings");

            migrationBuilder.RenameColumn(
                name: "TraineePrice",
                table: "Offerings",
                newName: "AppointmentId");

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "Offerings",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Appointments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId",
                table: "Appointments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
