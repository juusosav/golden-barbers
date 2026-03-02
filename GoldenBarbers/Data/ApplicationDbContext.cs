using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace GoldenBarbers.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Barber> Barbers { get; set; }

        public DbSet<Offering> Offerings { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Carousel> CarouselItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Barber>(b =>
            {
                b.Property(x => x.Name).IsRequired();
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
                        Portrait = "/images/John_headshot.jpg"
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
                        Portrait = "/images/Rebecca_headshot.jpg"
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
                        Portrait = "/images/Charles_headshot.jpg"
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
                        Portrait = "/images/Sarah_headshot.jpg"
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
                        Portrait = "/images/Hannah_headshot.jpg"
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
                        Portrait = "/images/Steve_headshot.jpg"
                    });
            });

            modelBuilder.Entity<Offering>(o =>
            {
                o.HasData(
                    new Offering
                    {
                        Id = new Guid("39cb2981-ab90-4971-a4aa-f22d5a7b0a9f"),
                        Name = "Barber Haircut",
                        Icon = "/images/barber_haircut.png",
                        Description = "Classic professional barber haircut.",
                        SeniorPrice = 38,
                        JuniorPrice = 30,
                        TraineePrice = 22
                    },
                    new Offering
                    {
                        Id = new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"),
                        Name = "Haircut & Beard Treatment",
                        Icon = "/images/haircut_beard_treatment.png",
                        Description = 
                            "Haircut with a complete beard treatment package including steaming and grooming",
                        SeniorPrice = 50,
                        JuniorPrice = 45,
                        TraineePrice = 37
                    },
                    new Offering
                    {
                        Id = new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                        Name = "Dutch Beard Treatment",
                        Icon = "/images/dutch_beard_treatment.png",
                        Description =
                            "The old-school treatment for a dutch beard style including finishing beard treatment with oils.",
                        SeniorPrice = 35,
                        JuniorPrice = 30,
                        TraineePrice = 25
                    },
                    new Offering
                    {
                        Id = new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                        Name = "American Beard Trim",
                        Icon = "/images/american_beard_trim.png",
                        Description =
                            "Classic american beard trimming with razorblade and foaming.",
                        SeniorPrice = 28,
                        JuniorPrice = 25,
                        TraineePrice = 23
                    }
                    );
            });

            modelBuilder.Entity<Carousel>(o =>
            {
                o.HasData(
                    new Carousel
                    {
                        Id = new Guid("14c09ff8-c38f-4d7e-9e27-7e498f4a446d"),
                        Image = "/images/barbershop_photo1.png",
                        Name = "Haircuts & Styling"
                    },
                    new Carousel
                    {
                        Id = new Guid("dad920d2-466b-4459-95ea-94a16693d66b"),
                        Image = "/images/barbershop_photo2.png",
                        Name = "Professional Beard Trimming"
                    },
                    new Carousel
                    {
                        Id = new Guid("88f713d6-b493-4e7c-8df2-a9bbe28ef472"),
                        Image = "/images/barbershop_photo3.png",
                        Name = "Beard Styling & Treatment"
                    }
                    );
            });
        }
    }
}

