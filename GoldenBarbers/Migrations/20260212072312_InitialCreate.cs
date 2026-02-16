using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Timeslot = table.Column<TimeSpan>(type: "interval", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    BarberId = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Barbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Portrait = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offerings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Rate = table.Column<double>(type: "double precision", nullable: false),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offerings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "Id", "Description", "Name", "Portrait", "Position" },
                values: new object[,]
                {
                    { new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"), "An up-and-coming talent in the beauty industry.", "Steve Robertson", "/images/Steve_headshot.jpg", "Trainee Hairdresser" },
                    { new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"), "Hallelujah!", "Hannah Lawson", "/images/Hannah_headshot.jpg", "Junior Hairdresser" },
                    { new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"), "Hair makes my day.", "Sarah Jones", "/images/Sarah_headshot.jpg", "Junior Hairdresser" },
                    { new Guid("db70dad6-650f-48ec-9867-66019827b11d"), "Style is not optional.", "Charles Jackson", "/images/Charles_headshot.jpg", "Junior Hairdresser" },
                    { new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"), "Multitalented barber.", "John Smith", "/images/John_headshot.jpg", "Senior Hairdresser" },
                    { new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"), "Astute eye for beauty and elegance.", "Rebecca Anderson", "/images/Rebecca_headshot.jpg", "Senior Hairdresser" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Barbers");

            migrationBuilder.DropTable(
                name: "Offerings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
