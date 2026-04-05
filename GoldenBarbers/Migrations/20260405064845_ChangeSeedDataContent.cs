using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeedDataContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("14c09ff8-c38f-4d7e-9e27-7e498f4a446d"),
                column: "Name",
                value: "Hiustenleikkaukset & stailaukset");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("88f713d6-b493-4e7c-8df2-a9bbe28ef472"),
                column: "Name",
                value: "Parran stailaus & hoito");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"),
                column: "Name",
                value: "Hiustenleikkaus & parran hoito");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("14c09ff8-c38f-4d7e-9e27-7e498f4a446d"),
                column: "Name",
                value: "Hiustenleikkaukset & Stailaukset");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("88f713d6-b493-4e7c-8df2-a9bbe28ef472"),
                column: "Name",
                value: "Parran stailaus & Hoito");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"),
                column: "Name",
                value: "Hiustenleikkaus & Parran hoito");
        }
    }
}
