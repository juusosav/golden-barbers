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

            modelBuilder.Entity<Offering>(o =>
            {
                o.Property(o => o.Name).IsRequired();
                o.Property(o => o.Description).IsRequired();
                o.Property(o => o.Icon).IsRequired();
                o.Property(o => o.SeniorPrice).IsRequired();
                o.Property(o => o.JuniorPrice).IsRequired();
                o.Property(o => o.TraineePrice).IsRequired();
            });

            modelBuilder.Entity<Carousel>(c =>
            {
                c.Property(c => c.Name).IsRequired();
                c.Property(c => c.Image).IsRequired();
            });

            modelBuilder.Entity<Appointment>(a =>
            {
                a.Property(a => a.BarberId).IsRequired();
                a.Property(a => a.BarberName).IsRequired();
                a.Property(a => a.OfferingId).IsRequired();
                a.Property(a => a.OfferingName).IsRequired();
                a.Property(a => a.AppointmentDateTime).IsRequired();
                a.Property(a => a.DurationMinutes).IsRequired();
                a.Property(a => a.CustomerName).IsRequired();
                a.Property(a => a.CustomerEmail).IsRequired();
                a.Property(a => a.FinalPrice).IsRequired();
            });

            BarberSeed.Seed(modelBuilder);
            OfferingSeed.Seed(modelBuilder);
            CarouselSeed.Seed(modelBuilder);
        }
    }
}

