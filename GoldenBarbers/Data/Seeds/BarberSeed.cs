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
                            "Johnilla on yli vuosikymmenen kokemus parturituolilla, " +
                            "ja hän on erikoistunut tarkkoihin häivytyksiin sekä klassisiin herrasmiesleikauksiin. " +
                            "Hänen huolellisuutensa ja rauhallinen työskentelytapansa tekevät jokaisesta käynnistä " +
                            "rennon ja ammattimaisen. Halusitpa sitten terävän modernin tyylin tai ajattoman ilmeen, " +
                            "John varmistaa, että lähdet liikkeestä itsevarmana.",
                        Portrait = "/images/John_headshot.jpg",
                        Salary = 2670.9m,
                        PersonalPhone = "045 4318 8088",
                        PersonalEmail = "john.s3@gmail.com",
                        PersonalAddress = "Mechelininkatu 23, Helsinki",
                        StartDate = DateTime.SpecifyKind(new DateTime(2024, 4, 12), DateTimeKind.Utc)
                    },
                    new Barber
                    {
                        Id = new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                        Name = "Rebecca Anderson",
                        PositionId = 1,
                        PositionName = "Senior Barber",
                        Description =
                            "Rebeccalla on luontainen kyky ymmärtää, mikä sopii kunkin asiakkaan " +
                            "kasvojen muotoon ja persoonallisuuteen. Hän on erikoistunut moderneihin leikkauksiin, " +
                            "teksturoituihin tyyleihin ja huolelliseen viimeistelyyn. Hänen lämmin ja " +
                            "vastaanottavainen otteensa tekee jokaisesta käynnistä mukavan ja yksilöllisen.",
                        Portrait = "/images/Rebecca_headshot.jpg",
                        Salary = 2530.7m,
                        PersonalPhone = "044 1834 6640",
                        PersonalEmail = "rebeccaa12@gmail.com",
                        PersonalAddress = "Hämeentie 47, Helsinki",
                        StartDate = DateTime.SpecifyKind(new DateTime(2024, 4, 12), DateTimeKind.Utc)
                    },
                    new Barber
                    {
                        Id = new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                        Name = "Charles Jackson",
                        PositionId = 1,
                        PositionName = "Senior Barber",
                        Description = "Charles tunnetaan tarkasta tyylisilmästään ja huolellisesti muotoilemistaan parroista. " +
                        "Intohimollaan perinteisiä parturitekniikoita ja moderneja trendejä kohtaan " +
                        "hän yhdistää näiden parhaat puolet. Asiakkaat arvostavat hänen " +
                        "ystävällistä luonnettaan ja omistautumistaan jokaisen yksityiskohdan viimeistelyyn.",
                        Portrait = "/images/Charles_headshot.jpg",
                        Salary = 2450.4m,
                        PersonalPhone = "050 4871 9510",
                        PersonalEmail = "charliejack@gmail.com",
                        PersonalAddress = "Lauttasaarentie 12, Helsinki",
                        StartDate = DateTime.SpecifyKind(new DateTime(2025, 1, 20), DateTimeKind.Utc)
                    },
                    new Barber
                    {
                        Id = new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                        Name = "Sarah Jones",
                        PositionId = 2,
                        PositionName = "Junior Barber",
                        Description = "Sarah tunnetaan vakaasta kädestään ja virheettömästä viimeistelytyöstään. " +
                        "Terävistä skin fade -häivytyksistä täydellisesti muotoiltuihin partoihin – hän lähestyy " +
                        "jokaista leikkausta keskittyneesti ja huolella. Asiakkaat arvostavat hänen ammattimaisuuttaan " +
                        "ja kykyään toteuttaa heidän visionsa. Hän uskoo, että erinomainen grooming perustuu " +
                        "tarkkuuteen ja johdonmukaisuuteen.",
                        Portrait = "/images/Sarah_headshot.jpg",
                        Salary = 2350.8m,
                        PersonalPhone = "045 7592 3593",
                        PersonalEmail = "sarahlee@hotmail.com",
                        PersonalAddress = "Fredrikinkatu 38, Helsinki",
                        StartDate = DateTime.SpecifyKind(new DateTime(2025, 8, 12), DateTimeKind.Utc)
                    },
                    new Barber
                    {
                        Id = new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                        Name = "Hannah Lawson",
                        PositionId = 2,
                        PositionName = "Junior Barber",
                        Description = "Hannah yhdistää luovuuden ja teknisen taidon tuottaakseen erinomaisia tuloksia. " +
                        "Hän nauttii työskentelystä sekä klassisten tyylien että rohkeiden modernien ilmeiden parissa, " +
                        "räätälöiden jokaisen leikkauksen yksilöllisesti. Hänen ystävällinen asenteensa ja " +
                        "tarkkuutensa tekevät hänestä asiakkaiden suosikin.",
                        Portrait = "/images/Hannah_headshot.jpg",
                        Salary = 2290.5m,
                        PersonalPhone = "050 6859 4772",
                        PersonalEmail = "hannah.law@gmail.com",
                        PersonalAddress = "Sturenkatu 61, Helsinki",
                        StartDate = DateTime.SpecifyKind(new DateTime(2025, 11, 2), DateTimeKind.Utc)
                    },
                    new Barber
                    {
                        Id = new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                        Name = "Steve Robertson",
                        PositionId = 3,
                        PositionName = "Trainee Barber",
                        Description = "Steve on lahjakas harjoittelijamme, joka tuo mukanaan tuoretta energiaa ja " +
                        "vahvan halun kehittyä alan ammattilaiseksi. Hän hioo taitojaan parhaillaan " +
                        "senioritiimimme ohjauksessa keskittyen siisteihin leikkauksiin ja tarkkoihin tyyleihin. " +
                        "Steve on yksityiskohtiin paneutuva, kärsivällinen ja sitoutunut jatkuvaan kehittymiseen.",
                        Portrait = "/images/Steve_headshot.jpg",
                        Salary = 2020.3m,
                        PersonalPhone = "045 5627 5582",
                        PersonalEmail = "stevie_robs@gmail.com",
                        PersonalAddress = "Itämerenkatu 5, Helsinki",
                        StartDate = DateTime.SpecifyKind(new DateTime(2026, 1, 20), DateTimeKind.Utc)
                    });
            });
        }
    }
}