using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToCarouselImageProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "CarouselItems",
                newName: "Image");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("14c09ff8-c38f-4d7e-9e27-7e498f4a446d"),
                columns: new[] { "Image", "Name" },
                values: new object[] { "/images/barbershop_photo1.png", "Haircuts" });

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("88f713d6-b493-4e7c-8df2-a9bbe28ef472"),
                columns: new[] { "Image", "Name" },
                values: new object[] { "/images/barbershop_photo3.png", "Beard Styling & Treatment" });

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("dad920d2-466b-4459-95ea-94a16693d66b"),
                columns: new[] { "Image", "Name" },
                values: new object[] { "/images/barbershop_photo2.png", "Professional Beard Trimming" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "CarouselItems",
                newName: "Icon");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("14c09ff8-c38f-4d7e-9e27-7e498f4a446d"),
                columns: new[] { "Icon", "Name" },
                values: new object[] { "/images/haircut_icon.png", "Barber Services" });

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("88f713d6-b493-4e7c-8df2-a9bbe28ef472"),
                columns: new[] { "Icon", "Name" },
                values: new object[] { "/images/hairstyle_icon.png", "Professional Hairstyling" });

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("dad920d2-466b-4459-95ea-94a16693d66b"),
                columns: new[] { "Icon", "Name" },
                values: new object[] { "/images/haircolor_icon.png", "Hair Coloring" });
        }
    }
}
