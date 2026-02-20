using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBarberAndOfferingSeedInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                columns: new[] { "Description", "Position" },
                values: new object[] { "Steve is our talented trainee, bringing fresh energy and a strong desire to master the craft. He is currently refining his skills under the guidance of our senior team, focusing on clean cuts and precise styling. Steve is detail-oriented, patient, and committed to continuous improvement.", "Trainee Barber" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                columns: new[] { "Description", "Position" },
                values: new object[] { "Hannah combines creativity with technical skill to deliver standout results. She enjoys working with both classic styles and bold, modern looks, always tailoring each cut to the individual. Her friendly attitude and attention to detail make her a favorite among clients.", "Creative Barber" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                columns: new[] { "Description", "Position" },
                values: new object[] { "Sarah is known for her steady hand and flawless finishing touches. From sharp skin fades to perfectly shaped beards, she approaches every cut with focus and care. Clients value her professionalism and ability to bring their vision to life. She believes great grooming is all about precision and consistency.", "Precision barber" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                columns: new[] { "Description", "Position" },
                values: new object[] { "Charles is known for his sharp eye for style and perfectly sculpted beard work. With a passion for traditional barbering techniques and modern trends, he blends the best of both worlds. Clients appreciate his friendly personality and dedication to getting every detail right.", "Master Barber" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"),
                columns: new[] { "Description", "Position" },
                values: new object[] { "John brings over a decade of experience to the chair, specializing in precision fades and classic gentleman’s cuts. His attention to detail and calm approach make every appointment feel relaxed and professional. Whether you’re after a sharp modern style or a timeless look, John ensures you leave feeling confident.", "Senior Barber" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                columns: new[] { "Description", "Position" },
                values: new object[] { "Rebecca has a natural talent for understanding what suits each client’s face shape and personality. She specializes in modern cuts, textured styles, and detailed finishing work. Her warm and welcoming approach ensures every visit feels comfortable and personalized.", "Style Specialist" });

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                column: "TraineePrice",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                column: "TraineePrice",
                value: 23);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                columns: new[] { "Description", "Position" },
                values: new object[] { "An up-and-coming talent in the beauty industry.", "Trainee Hairdresser" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                columns: new[] { "Description", "Position" },
                values: new object[] { "Hallelujah!", "Junior Hairdresser" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                columns: new[] { "Description", "Position" },
                values: new object[] { "Hair makes my day.", "Junior Hairdresser" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                columns: new[] { "Description", "Position" },
                values: new object[] { "Style is not optional.", "Junior Hairdresser" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"),
                columns: new[] { "Description", "Position" },
                values: new object[] { "Multitalented barber.", "Senior Hairdresser" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                columns: new[] { "Description", "Position" },
                values: new object[] { "Astute eye for beauty and elegance.", "Senior Hairdresser" });

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                column: "TraineePrice",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                column: "TraineePrice",
                value: 22);
        }
    }
}
