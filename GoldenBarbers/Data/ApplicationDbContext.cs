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

            BarberSeed.Seed(modelBuilder);
            OfferingSeed.Seed(modelBuilder);
            CarouselSeed.Seed(modelBuilder);
        }
    }
}

