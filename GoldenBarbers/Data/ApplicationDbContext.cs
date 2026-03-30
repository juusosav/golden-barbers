using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GoldenBarbers.Models.Entities;
using Microsoft.AspNetCore.Identity;
using GoldenBarbers.Data.Seeds;

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


            // TODO: Extract PositionId to a new entity, FK to Barber
            modelBuilder.Entity<Barber>(b =>
            {
                b.Property(x => x.Name).IsRequired();
                b.Property(x => x.PositionId).IsRequired();
                b.Property(x => x.PositionName).IsRequired();
                b.Property(x => x.Salary).IsRequired();
                b.Property(x => x.Portrait).IsRequired();
                b.Property(x => x.PersonalPhone).IsRequired();
                b.Property(x => x.PersonalEmail).IsRequired();
                b.Property(x => x.PersonalAddress).IsRequired();
                b.Property(x => x.StartDate).IsRequired();
            });

            BarberSeed.Seed(modelBuilder);
            OfferingSeed.Seed(modelBuilder);
            CarouselSeed.Seed(modelBuilder);
        }
    }
}

