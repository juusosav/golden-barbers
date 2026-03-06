using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAppointmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                table: "Appointments",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Appointments");
        }
    }
}
