using GoldenBarbers.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenBarbers.Data.Seeds
{
    public static class CarouselSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carousel>(o =>
            {
                o.HasData(
                    new Carousel
                    {
                        Id = new Guid("14c09ff8-c38f-4d7e-9e27-7e498f4a446d"),
                        Image = "/images/barbershop_photo1.png",
                        Name = "Hiustenleikkaukset & Stailaukset"
                    },
                    new Carousel
                    {
                        Id = new Guid("dad920d2-466b-4459-95ea-94a16693d66b"),
                        Image = "/images/barbershop_photo2.png",
                        Name = "Ammattimainen parran trimmaus"
                    },
                    new Carousel
                    {
                        Id = new Guid("88f713d6-b493-4e7c-8df2-a9bbe28ef472"),
                        Image = "/images/barbershop_photo3.png",
                        Name = "Parran stailaus & Hoito"
                    }
                    );
            });
        }
    }
}
