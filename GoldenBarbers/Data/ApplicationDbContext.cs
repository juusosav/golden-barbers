using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Models.Entities;

namespace GoldenBarbers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Barber> Barbers { get; set; }

        public DbSet<Offering> Offerings { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Carousel> CarouselItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barber>(b =>
            {
                b.Property(x => x.Name).IsRequired();
                b.HasData(
                    new Barber
                    {
                        Id = new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"),
                        Name = "John Smith",
                        Position = "Senior Hairdresser",
                        Description = "Multitalented barber.",
                        Portrait = "/images/John_headshot.jpg"
                    },
                    new Barber
                    {
                        Id = new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                        Name = "Rebecca Anderson",
                        Position = "Senior Hairdresser",
                        Description = "Astute eye for beauty and elegance.",
                        Portrait = "/images/Rebecca_headshot.jpg"
                    },
                    new Barber
                    {
                        Id = new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                        Name = "Charles Jackson",
                        Position = "Junior Hairdresser",
                        Description = "Style is not optional.",
                        Portrait = "/images/Charles_headshot.jpg"
                    },
                    new Barber
                    {
                        Id = new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                        Name = "Sarah Jones",
                        Position = "Junior Hairdresser",
                        Description = "Hair makes my day.",
                        Portrait = "/images/Sarah_headshot.jpg"
                    },
                    new Barber
                    {
                        Id = new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                        Name = "Hannah Lawson",
                        Position = "Junior Hairdresser",
                        Description = "Hallelujah!",
                        Portrait = "/images/Hannah_headshot.jpg"
                    },
                    new Barber
                    {
                        Id = new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                        Name = "Steve Robertson",
                        Position = "Trainee Hairdresser",
                        Description = "An up-and-coming talent in the beauty industry.",
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
                        SeniorPrice = 38,
                        JuniorPrice = 30,
                        TraineePrice = 22
                    },
                    new Offering
                    {
                        Id = new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"),
                        Name = "Short Hair Coloring and Haircut",
                        SeniorPrice = 100,
                        JuniorPrice = 90,
                        TraineePrice = 75
                    },
                    new Offering
                    {
                        Id = new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                        Name = "Long Hair Coloring with Haircut",
                        SeniorPrice = 130,
                        JuniorPrice = 118,
                        TraineePrice = 100
                    },
                    new Offering
                    {
                        Id = new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                        Name = "Party Hairstyling with Haircut",
                        SeniorPrice = 70,
                        JuniorPrice = 58,
                        TraineePrice = 50
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
                        Name = "Haircuts"
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

