using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class AddLangSpecificPropertiesToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Offerings",
                newName: "NameFi");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Offerings",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Barbers",
                newName: "DescriptionFi");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Offerings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionFi",
                table: "Offerings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Barbers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                column: "DescriptionEn",
                value: "Steve is our talented trainee, bringing fresh energy and a strong desire to master the craft. He is currently refining his skills under the guidance of our senior team, focusing on clean cuts and precise styling. Steve is detail-oriented, patient, and committed to continuous improvement.");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                column: "DescriptionEn",
                value: "Hannah combines creativity with technical skill to deliver standout results. She enjoys working with both classic styles and bold, modern looks, always tailoring each cut to the individual. Her friendly attitude and attention to detail make her a favorite among clients.");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                column: "DescriptionEn",
                value: "Sarah is known for her steady hand and flawless finishing touches. From sharp skin fades to perfectly shaped beards, she approaches every cut with focus and care. Clients value her professionalism and ability to bring their vision to life. She believes great grooming is all about precision and consistency.");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                column: "DescriptionEn",
                value: "Charles is known for his sharp eye for style and perfectly sculpted beard work. With a passion for traditional barbering techniques and modern trends, he blends the best of both worlds. Clients appreciate his friendly personality and dedication to getting every detail right.");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"),
                column: "DescriptionEn",
                value: "John brings over a decade of experience to the chair, specializing in precision fades and classic gentleman’s cuts. His attention to detail and calm approach make every appointment feel relaxed and professional. Whether you’re after a sharp modern style or a timeless look, John ensures you leave feeling confident.");

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                column: "DescriptionEn",
                value: "Rebecca has a natural talent for understanding what suits each client’s face shape and personality. She specializes in modern cuts, textured styles, and detailed finishing work. Her warm and welcoming approach ensures every visit feels comfortable and personalized.");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                columns: new[] { "DescriptionEn", "DescriptionFi", "NameEn" },
                values: new object[] { "Old-school treatment package for a dutch beard style includingfinishing with oils", "Vanhan koulukunnan hoitopaketti hollantilaisen partatyylin mukaan sisältäen hoitoviimeistelyn öljyillä", "Dutch beard treatment" });

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("39cb2981-ab90-4971-a4aa-f22d5a7b0a9f"),
                columns: new[] { "DescriptionEn", "DescriptionFi", "NameEn" },
                values: new object[] { "Classic high-quality barber haircut", "Klassinen korkealaatuinen parturileikkaus", "Barber haircut" });

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"),
                columns: new[] { "DescriptionEn", "DescriptionFi", "NameEn" },
                values: new object[] { "", "Hiustenleikkaus täydellisellä parran hoitopaketilla, sisältää höyrytyksen ja siistimisen", "Haircut & beard treatment" });

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                columns: new[] { "DescriptionEn", "DescriptionFi", "NameEn" },
                values: new object[] { "Classic american beard trimming with a razorblade and foaming", "Klassinen amerikkalainen parran trimmaus partaterällä ja vaahdotuksella", "American beard trimming" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Offerings");

            migrationBuilder.DropColumn(
                name: "DescriptionFi",
                table: "Offerings");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Barbers");

            migrationBuilder.RenameColumn(
                name: "NameFi",
                table: "Offerings",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Offerings",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "DescriptionFi",
                table: "Barbers",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                column: "Description",
                value: "Vanhan koulun hoitopaketti hollantilaisen partatyylin mukaan sisältäen hoitoviimeistelyn öljyillä");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("39cb2981-ab90-4971-a4aa-f22d5a7b0a9f"),
                column: "Description",
                value: "Klassinen korkealaatuinen parturileikkaus");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"),
                column: "Description",
                value: "Hiustenleikkaus täydellisellä parran hoitopaketilla, sisältää höyrytyksen ja siistimisen");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                column: "Description",
                value: "Klassinen amerikkalainen parran trimmaus partaterällä ja vaahdotuksella");
        }
    }
}
