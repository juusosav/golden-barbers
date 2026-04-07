using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class AddCarouselLangSpecificProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CarouselItems",
                newName: "NameFi");

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "CarouselItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("14c09ff8-c38f-4d7e-9e27-7e498f4a446d"),
                column: "NameEn",
                value: "Haircuts & styling");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("88f713d6-b493-4e7c-8df2-a9bbe28ef472"),
                column: "NameEn",
                value: "Beard styling & treatment");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("dad920d2-466b-4459-95ea-94a16693d66b"),
                column: "NameEn",
                value: "Professional beard trimming");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "CarouselItems");

            migrationBuilder.RenameColumn(
                name: "NameFi",
                table: "CarouselItems",
                newName: "Name");
        }
    }
}
