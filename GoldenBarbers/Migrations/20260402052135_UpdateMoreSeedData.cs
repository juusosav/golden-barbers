using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMoreSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                column: "PersonalPhone",
                value: "045 5627 5582");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                column: "PersonalPhone",
                value: "050 6859 4772");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                column: "PersonalPhone",
                value: "045 7592 3593");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                column: "PersonalPhone",
                value: "050 4871 9510");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"),
                column: "PersonalPhone",
                value: "045 4318 8088");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                column: "PersonalPhone",
                value: "044 1834 6640");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("88f713d6-b493-4e7c-8df2-a9bbe28ef472"),
                column: "Name",
                value: "Parran stailaus & Hoito");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                column: "Name",
                value: "Hollantilainen partahoito");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"),
                column: "Name",
                value: "Hiustenleikkaus & Parran hoito");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                column: "Name",
                value: "Amerikkalainen parran trimmaus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                column: "PersonalPhone",
                value: "077 5627 5582");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                column: "PersonalPhone",
                value: "070 6859 4772");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                column: "PersonalPhone",
                value: "078 7592 3593");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                column: "PersonalPhone",
                value: "070 4871 9510");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"),
                column: "PersonalPhone",
                value: "079 4318 8088");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                column: "PersonalPhone",
                value: "078 1834 6640");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("88f713d6-b493-4e7c-8df2-a9bbe28ef472"),
                column: "Name",
                value: "Parran Stailaus & Hoito");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                column: "Name",
                value: "Dutch Beard Treatment");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"),
                column: "Name",
                value: "Hiustenleikkaus & Parran Hoito");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                column: "Name",
                value: "American Beard Trim");
        }
    }
}
