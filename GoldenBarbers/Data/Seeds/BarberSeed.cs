using GoldenBarbers.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenBarbers.Data.Seeds
{
    public static class BarberSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barber>(b =>
            {
                b.HasData(
                    new Barber
                    {
                        Id = new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"),
                        Name = "John Smith",
                        PositionId = 1,
                        PositionName = "Senior Barber",
                        Description =
                            "John brings over a decade of experience to the chair, " +
                            "specializing in precision fades and classic gentleman’s cuts. " +
                            "His attention to detail and calm approach make every appointment feel relaxed and professional. " +
                            "Whether you’re after a sharp modern style or a timeless look, " +
                            "John ensures you leave feeling confident.",
                        Portrait = "/images/John_headshot.jpg",
                        Salary = 2670.9m,
                        PersonalPhone = "079 4318 8088",
                        PersonalEmail = "john.s3@gmail.com",
                        PersonalAddress = "51 Church Lane, London",
                        StartDate = DateTime.SpecifyKind(new DateTime(2024, 4, 12), DateTimeKind.Utc)
                    },
                    new Barber
                    {
                        Id = new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                        Name = "Rebecca Anderson",
                        PositionId = 1,
                        PositionName = "Senior Barber",
                        Description =
                            "Rebecca has a natural talent for understanding what suits each client’s " +
                            "face shape and personality. She specializes in modern cuts, textured styles, " +
                            "and detailed finishing work. Her warm and welcoming approach ensures every visit " +
                            "feels comfortable and personalized.",
                        Portrait = "/images/Rebecca_headshot.jpg",
                        Salary = 2530.7m,
                        PersonalPhone = "078 1834 6640",
                        PersonalEmail = "rebeccaa12@gmail.com",
                        PersonalAddress = "66 Station Road, London",
                        StartDate = DateTime.SpecifyKind(new DateTime(2024, 4, 12), DateTimeKind.Utc)
                    },
                    new Barber
                    {
                        Id = new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                        Name = "Charles Jackson",
                        PositionId = 1,
                        PositionName = "Senior Barber",
                        Description = "Charles is known for his sharp eye for style and perfectly sculpted beard work. " +
                        "With a passion for traditional barbering techniques and modern trends, " +
                        "he blends the best of both worlds. Clients appreciate his friendly personality and dedication " +
                        "to getting every detail right.",
                        Portrait = "/images/Charles_headshot.jpg",
                        Salary = 2450.4m,
                        PersonalPhone = "070 4871 9510",
                        PersonalEmail = "charliejack@gmail.com",
                        PersonalAddress = "24 Lionsdale Ave, London",
                        StartDate = DateTime.SpecifyKind(new DateTime(2025, 1, 20), DateTimeKind.Utc)
                    },
                    new Barber
                    {
                        Id = new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                        Name = "Sarah Jones",
                        PositionId = 2,
                        PositionName = "Junior Barber",
                        Description = "Sarah is known for her steady hand and flawless finishing touches. " +
                        "From sharp skin fades to perfectly shaped beards, she approaches every cut with focus and care. " +
                        "Clients value her professionalism and ability to bring their vision to life. " +
                        "She believes great grooming is all about precision and consistency.",
                        Portrait = "/images/Sarah_headshot.jpg",
                        Salary = 2350.8m,
                        PersonalPhone = "078 7592 3593",
                        PersonalEmail = "sarahlee@hotmail.com",
                        PersonalAddress = "52 Cassland Road, London",
                        StartDate = DateTime.SpecifyKind(new DateTime(2025, 8, 12), DateTimeKind.Utc)
                    },
                    new Barber
                    {
                        Id = new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                        Name = "Hannah Lawson",
                        PositionId = 2,
                        PositionName = "Junior Barber",
                        Description = "Hannah combines creativity with technical skill to deliver standout results. " +
                        "She enjoys working with both classic styles and bold, modern looks, always tailoring each cut " +
                        "to the individual. Her friendly attitude and attention to " +
                        "detail make her a favorite among clients.",
                        Portrait = "/images/Hannah_headshot.jpg",
                        Salary = 2290.5m,
                        PersonalPhone = "070 6859 4772",
                        PersonalEmail = "hannah.law@gmail.com",
                        PersonalAddress = "21 Manor Road, London",
                        StartDate = DateTime.SpecifyKind(new DateTime(2025, 11, 2), DateTimeKind.Utc)
                    },
                    new Barber
                    {
                        Id = new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                        Name = "Steve Robertson",
                        PositionId = 3,
                        PositionName = "Trainee Barber",
                        Description = "Steve is our talented trainee, bringing fresh energy and a strong desire to " +
                        "master the craft. He is currently refining his skills under the guidance of our senior team, " +
                        "focusing on clean cuts and precise styling. Steve is detail-oriented, patient, and " +
                        "committed to continuous improvement.",
                        Portrait = "/images/Steve_headshot.jpg",
                        Salary = 2020.3m,
                        PersonalPhone = "077 5627 5582",
                        PersonalEmail = "stevie_robs@gmail.com",
                        PersonalAddress = "52 Victoria Road, London",
                        StartDate = DateTime.SpecifyKind(new DateTime(2026, 1, 20), DateTimeKind.Utc)
                    });
            });
        }
    }
}
