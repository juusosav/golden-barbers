using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenBarbers.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                columns: new[] { "Description", "PersonalAddress" },
                values: new object[] { "Steve on lahjakas harjoittelijamme, joka tuo mukanaan tuoretta energiaa ja vahvan halun kehittyä alan ammattilaiseksi. Hän hioo taitojaan parhaillaan senioritiimimme ohjauksessa keskittyen siisteihin leikkauksiin ja tarkkoihin tyyleihin. Steve on yksityiskohtiin paneutuva, kärsivällinen ja sitoutunut jatkuvaan kehittymiseen.", "Itämerenkatu 5, Helsinki" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                columns: new[] { "Description", "PersonalAddress" },
                values: new object[] { "Hannah yhdistää luovuuden ja teknisen taidon tuottaakseen erinomaisia tuloksia. Hän nauttii työskentelystä sekä klassisten tyylien että rohkeiden modernien ilmeiden parissa, räätälöiden jokaisen leikkauksen yksilöllisesti. Hänen ystävällinen asenteensa ja tarkkuutensa tekevät hänestä asiakkaiden suosikin.", "Sturenkatu 61, Helsinki" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                columns: new[] { "Description", "PersonalAddress" },
                values: new object[] { "Sarah tunnetaan vakaasta kädestään ja virheettömästä viimeistelytyöstään. Terävistä skin fade -häivytyksistä täydellisesti muotoiltuihin partoihin – hän lähestyy jokaista leikkausta keskittyneesti ja huolella. Asiakkaat arvostavat hänen ammattimaisuuttaan ja kykyään toteuttaa heidän visionsa. Hän uskoo, että erinomainen grooming perustuu tarkkuuteen ja johdonmukaisuuteen.", "Fredrikinkatu 38, Helsinki" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                columns: new[] { "Description", "PersonalAddress" },
                values: new object[] { "Charles tunnetaan tarkasta tyylisilmästään ja huolellisesti muotoilemistaan parroista. Intohimollaan perinteisiä parturitekniikoita ja moderneja trendejä kohtaan hän yhdistää näiden parhaat puolet. Asiakkaat arvostavat hänen ystävällistä luonnettaan ja omistautumistaan jokaisen yksityiskohdan viimeistelyyn.", "Lauttasaarentie 12, Helsinki" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"),
                columns: new[] { "Description", "PersonalAddress" },
                values: new object[] { "Johnilla on yli vuosikymmenen kokemus parturituolilla, ja hän on erikoistunut tarkkoihin häivytyksiin sekä klassisiin herrasmiesleikauksiin. Hänen huolellisuutensa ja rauhallinen työskentelytapansa tekevät jokaisesta käynnistä rennon ja ammattimaisen. Halusitpa sitten terävän modernin tyylin tai ajattoman ilmeen, John varmistaa, että lähdet liikkeestä itsevarmana.", "Mechelininkatu 23, Helsinki" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                columns: new[] { "Description", "PersonalAddress" },
                values: new object[] { "Rebeccalla on luontainen kyky ymmärtää, mikä sopii kunkin asiakkaan kasvojen muotoon ja persoonallisuuteen. Hän on erikoistunut moderneihin leikkauksiin, teksturoituihin tyyleihin ja huolelliseen viimeistelyyn. Hänen lämmin ja vastaanottavainen otteensa tekee jokaisesta käynnistä mukavan ja yksilöllisen.", "Hämeentie 47, Helsinki" });

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("14c09ff8-c38f-4d7e-9e27-7e498f4a446d"),
                column: "Name",
                value: "Hiustenleikkaukset & Stailaukset");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("88f713d6-b493-4e7c-8df2-a9bbe28ef472"),
                column: "Name",
                value: "Parran Stailaus & Hoito");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("dad920d2-466b-4459-95ea-94a16693d66b"),
                column: "Name",
                value: "Ammattimainen parran trimmaus");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                column: "Description",
                value: "Vanhan koulun hoitopaketti hollantilaisen partatyylin mukaan sisältäen hoitoviimeistelyn öljyillä");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("39cb2981-ab90-4971-a4aa-f22d5a7b0a9f"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Klassinen korkealaatuinen parturileikkaus", "Parturileikkaus" });

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Hiustenleikkaus täydellisellä parran hoitopaketilla, sisältää höyrytyksen ja siistimisen", "Hiustenleikkaus & Parran Hoito" });

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                column: "Description",
                value: "Klassinen amerikkalainen parran trimmaus partaterällä ja vaahdotuksella");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("2fecf3a8-0b1b-464d-9603-288fd86ccd13"),
                columns: new[] { "Description", "PersonalAddress" },
                values: new object[] { "Steve is our talented trainee, bringing fresh energy and a strong desire to master the craft. He is currently refining his skills under the guidance of our senior team, focusing on clean cuts and precise styling. Steve is detail-oriented, patient, and committed to continuous improvement.", "52 Victoria Road, London" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("55cd3319-dbf0-40fd-84f9-6c7d6ff08305"),
                columns: new[] { "Description", "PersonalAddress" },
                values: new object[] { "Hannah combines creativity with technical skill to deliver standout results. She enjoys working with both classic styles and bold, modern looks, always tailoring each cut to the individual. Her friendly attitude and attention to detail make her a favorite among clients.", "21 Manor Road, London" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("8da88ae7-30a0-46d2-bd0e-3c33fff09fa0"),
                columns: new[] { "Description", "PersonalAddress" },
                values: new object[] { "Sarah is known for her steady hand and flawless finishing touches. From sharp skin fades to perfectly shaped beards, she approaches every cut with focus and care. Clients value her professionalism and ability to bring their vision to life. She believes great grooming is all about precision and consistency.", "52 Cassland Road, London" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("db70dad6-650f-48ec-9867-66019827b11d"),
                columns: new[] { "Description", "PersonalAddress" },
                values: new object[] { "Charles is known for his sharp eye for style and perfectly sculpted beard work. With a passion for traditional barbering techniques and modern trends, he blends the best of both worlds. Clients appreciate his friendly personality and dedication to getting every detail right.", "24 Lionsdale Ave, London" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("dfe81b2e-4310-4f31-ad0b-ace635786aef"),
                columns: new[] { "Description", "PersonalAddress" },
                values: new object[] { "John brings over a decade of experience to the chair, specializing in precision fades and classic gentleman’s cuts. His attention to detail and calm approach make every appointment feel relaxed and professional. Whether you’re after a sharp modern style or a timeless look, John ensures you leave feeling confident.", "51 Church Lane, London" });

            migrationBuilder.UpdateData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: new Guid("fe04ae76-45e3-4b91-98f3-0eae566f5850"),
                columns: new[] { "Description", "PersonalAddress" },
                values: new object[] { "Rebecca has a natural talent for understanding what suits each client’s face shape and personality. She specializes in modern cuts, textured styles, and detailed finishing work. Her warm and welcoming approach ensures every visit feels comfortable and personalized.", "66 Station Road, London" });

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("14c09ff8-c38f-4d7e-9e27-7e498f4a446d"),
                column: "Name",
                value: "Haircuts & Styling");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("88f713d6-b493-4e7c-8df2-a9bbe28ef472"),
                column: "Name",
                value: "Beard Styling & Treatment");

            migrationBuilder.UpdateData(
                table: "CarouselItems",
                keyColumn: "Id",
                keyValue: new Guid("dad920d2-466b-4459-95ea-94a16693d66b"),
                column: "Name",
                value: "Professional Beard Trimming");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("353a0efa-a853-4393-819f-fe36f771cf3b"),
                column: "Description",
                value: "The old-school treatment for a dutch beard style including finishing beard treatment with oils.");

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("39cb2981-ab90-4971-a4aa-f22d5a7b0a9f"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Classic professional barber haircut.", "Barber Haircut" });

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("55583c0e-9d27-4af5-af9d-1508bd3e3e3f"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Haircut with a complete beard treatment package including steaming and grooming", "Haircut & Beard Treatment" });

            migrationBuilder.UpdateData(
                table: "Offerings",
                keyColumn: "Id",
                keyValue: new Guid("e7efb624-fa78-4bd5-9c29-cb710e32d0cc"),
                column: "Description",
                value: "Classic american beard trimming with razorblade and foaming.");
        }
    }
}
