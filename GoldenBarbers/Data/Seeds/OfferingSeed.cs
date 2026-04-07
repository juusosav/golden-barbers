using GoldenBarbers.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldenBarbers.Data.Seeds
{
    public static class OfferingSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offering>(o =>
            {
                o.HasData(
                    new Offering
                    {
                        Id = new Guid("39cb2981-ab90-4971-a4aa-f22d5a7b0a9f"),
                        NameFi = "Parturileikkaus",
                        NameEn = "Barber haircut",
                        Icon = "/images/barber_haircut.png",
                        DescriptionFi = "Klassinen korkealaatuinen parturileikkaus",
                        DescriptionEn = "Classic high-quality barber haircut",
                        SeniorPrice = 38,
                        JuniorPrice = 30,
                        TraineePrice = 22
                    },
                    new Offering
                    {
                        Id = new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"),
                        NameFi = "Hiustenleikkaus & parran hoito",
                        NameEn = "Haircut & beard treatment",
                        Icon = "/images/haircut_beard_treatment.png",
                        DescriptionFi =
                            "Hiustenleikkaus täydellisellä parran hoitopaketilla, sisältää höyrytyksen ja siistimisen",
                        SeniorPrice = 50,
                        JuniorPrice = 45,
                        TraineePrice = 37
                    },
                    new Offering
                    {
                        Id = new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                        NameFi = "Hollantilainen partahoito",
                        NameEn = "Dutch beard treatment",
                        Icon = "/images/dutch_beard_treatment.png",
                        DescriptionFi =
                            "Vanhan koulukunnan hoitopaketti hollantilaisen partatyylin mukaan sisältäen " +
                            "hoitoviimeistelyn öljyillä",
                        DescriptionEn =
                            "Old-school treatment package for a dutch beard style including" +
                            "finishing with oils",
                        SeniorPrice = 35,
                        JuniorPrice = 30,
                        TraineePrice = 25
                    },
                    new Offering
                    {
                        Id = new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                        NameFi = "Amerikkalainen parran trimmaus",
                        NameEn = "American beard trimming",
                        Icon = "/images/american_beard_trim.png",
                        DescriptionFi =
                            "Klassinen amerikkalainen parran trimmaus partaterällä ja vaahdotuksella",
                        DescriptionEn =
                            "Classic american beard trimming with a razorblade and foaming",
                        SeniorPrice = 28,
                        JuniorPrice = 25,
                        TraineePrice = 23
                    }
                    );
            });
        }
    }
}
