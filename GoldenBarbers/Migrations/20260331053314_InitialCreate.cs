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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AppointmentDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DurationMinutes = table.Column<int>(type: "INTEGER", nullable: false),
                    BarberId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BarberName = table.Column<string>(type: "TEXT", nullable: false),
                    OfferingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OfferingName = table.Column<string>(type: "TEXT", nullable: false),
                    BarberPositionId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerEmail = table.Column<string>(type: "TEXT", nullable: false),
                    FinalPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Barbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PositionId = table.Column<int>(type: "INTEGER", nullable: false),
                    PositionName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Portrait = table.Column<string>(type: "TEXT", nullable: false),
                    Salary = table.Column<decimal>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PersonalEmail = table.Column<string>(type: "TEXT", nullable: false),
                    PersonalPhone = table.Column<string>(type: "TEXT", nullable: false),
                    PersonalAddress = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarouselItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarouselItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offerings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    SeniorPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    JuniorPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    TraineePrice = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offerings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentOffering",
                columns: table => new
                {
                    AppointmentsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OfferingsId = table.Column<Guid>(type: "TEXT", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "Id", "Description", "Name", "PersonalAddress", "PersonalEmail", "PersonalPhone", "Portrait", "PositionId", "PositionName", "Salary", "StartDate" },
                values: new object[,]
                {
                    { new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"), "Steve is our talented trainee, bringing fresh energy and a strong desire to master the craft. He is currently refining his skills under the guidance of our senior team, focusing on clean cuts and precise styling. Steve is detail-oriented, patient, and committed to continuous improvement.", "Steve Robertson", "52 Victoria Road, London", "stevie_robs@gmail.com", "077 5627 5582", "/images/Steve_headshot.jpg", 3, "Trainee Barber", 2020.3m, new DateTime(2026, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"), "Hannah combines creativity with technical skill to deliver standout results. She enjoys working with both classic styles and bold, modern looks, always tailoring each cut to the individual. Her friendly attitude and attention to detail make her a favorite among clients.", "Hannah Lawson", "21 Manor Road, London", "hannah.law@gmail.com", "070 6859 4772", "/images/Hannah_headshot.jpg", 2, "Junior Barber", 2290.5m, new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"), "Sarah is known for her steady hand and flawless finishing touches. From sharp skin fades to perfectly shaped beards, she approaches every cut with focus and care. Clients value her professionalism and ability to bring their vision to life. She believes great grooming is all about precision and consistency.", "Sarah Jones", "52 Cassland Road, London", "sarahlee@hotmail.com", "078 7592 3593", "/images/Sarah_headshot.jpg", 2, "Junior Barber", 2350.8m, new DateTime(2025, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("db70dad6-650f-48ec-9867-66019827b11d"), "Charles is known for his sharp eye for style and perfectly sculpted beard work. With a passion for traditional barbering techniques and modern trends, he blends the best of both worlds. Clients appreciate his friendly personality and dedication to getting every detail right.", "Charles Jackson", "24 Lionsdale Ave, London", "charliejack@gmail.com", "070 4871 9510", "/images/Charles_headshot.jpg", 1, "Senior Barber", 2450.4m, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"), "John brings over a decade of experience to the chair, specializing in precision fades and classic gentleman’s cuts. His attention to detail and calm approach make every appointment feel relaxed and professional. Whether you’re after a sharp modern style or a timeless look, John ensures you leave feeling confident.", "John Smith", "51 Church Lane, London", "john.s3@gmail.com", "079 4318 8088", "/images/John_headshot.jpg", 1, "Senior Barber", 2670.9m, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"), "Rebecca has a natural talent for understanding what suits each client’s face shape and personality. She specializes in modern cuts, textured styles, and detailed finishing work. Her warm and welcoming approach ensures every visit feels comfortable and personalized.", "Rebecca Anderson", "66 Station Road, London", "rebeccaa12@gmail.com", "078 1834 6640", "/images/Rebecca_headshot.jpg", 1, "Senior Barber", 2530.7m, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "CarouselItems",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("14c09ff8-c38f-4d7e-9e27-7e498f4a446d"), "/images/barbershop_photo1.png", "Haircuts & Styling" },
                    { new Guid("88f713d6-b493-4e7c-8df2-a9bbe28ef472"), "/images/barbershop_photo3.png", "Beard Styling & Treatment" },
                    { new Guid("dad920d2-466b-4459-95ea-94a16693d66b"), "/images/barbershop_photo2.png", "Professional Beard Trimming" }
                });

            migrationBuilder.InsertData(
                table: "Offerings",
                columns: new[] { "Id", "Description", "Icon", "JuniorPrice", "Name", "SeniorPrice", "TraineePrice" },
                values: new object[,]
                {
                    { new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"), "The old-school treatment for a dutch beard style including finishing beard treatment with oils.", "/images/dutch_beard_treatment.png", 30, "Dutch Beard Treatment", 35, 25 },
                    { new Guid("39cb2981-ab90-4971-a4aa-f22d5a7b0a9f"), "Classic professional barber haircut.", "/images/barber_haircut.png", 30, "Barber Haircut", 38, 22 },
                    { new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"), "Haircut with a complete beard treatment package including steaming and grooming", "/images/haircut_beard_treatment.png", 45, "Haircut & Beard Treatment", 50, 37 },
                    { new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"), "Classic american beard trimming with razorblade and foaming.", "/images/american_beard_trim.png", 25, "American Beard Trim", 28, 23 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentOffering_OfferingsId",
                table: "AppointmentOffering",
                column: "OfferingsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentOffering");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Barbers");

            migrationBuilder.DropTable(
                name: "CarouselItems");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Offerings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
