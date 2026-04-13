using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class AddOfferingNameLocalizationToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OfferingName",
                table: "Appointments",
                newName: "OfferingNameFi");

            migrationBuilder.AddColumn<string>(
                name: "OfferingNameEn",
                table: "Appointments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferingNameEn",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "OfferingNameFi",
                table: "Appointments",
                newName: "OfferingName");
        }
    }
}
