using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaExperience.Infrastructure.Migrations
{
    public partial class SeededDunePartTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Biography", "BirthDate", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 11, "Timothee Hal Chalamet is an American actor. He began his acting career in short films, before appearing in the television drama series Homeland in 2012. Two years later, he made his feature film debut in the drama", new DateTime(1995, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Timothee_Chalamet.jpg", "Timothee Chalamet" },
                    { 12, "Zendaya Maree Stoermer Coleman is an American actress and singer. She began her career as a child model and backup dancer, before gaining prominence for her role as Rocky Blue on the Disney Channel sitcom Shake It Up (2010–2013). In 2013, Zendaya was a contestant on the sixteenth season of the competition series Dancing with the Stars. From 2015 to 2018, she produced and starred as the titular spy, K.C. Cooper, in the sitcom K.C. Undercover, and in 2019, she began playing the lead role in the HBO drama series Euphoria.", new DateTime(1996, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Zendaya.jpg", "Zendaya" },
                    { 13, "Rebecca Louisa Ferguson Sundström is a Swedish actress. She began her acting career with the Swedish soap opera Nya tider (1999–2000) and went on to star in the slasher film Drowning Ghost (2004). She came to international prominence with her portrayal of Elizabeth Woodville in the British television miniseries The White Queen (2013), for which she was nominated for a Golden Globe for Best Actress in a Miniseries or Television Film.", new DateTime(1983, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Rebecca_Ferguson.jpg", "Rebecca Ferguson" },
                    { 14, "Javier Ángel Encinas Bardem is a Spanish actor. Bardem won the Academy Award for Best Supporting Actor for his role as the psychopathic assassin Anton Chigurh in the 2007 Coen Brothers film", new DateTime(1969, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Javier_Bardem.jpg", "Javier Bardem" },
                    { 15, "Austin Robert Butler is an American actor and singer. He is known for his roles as James Wilke Wilkerson in Switched at Birth, Jordan Gallagher on Ruby & The Rockits, Sebastian Kydd in The Carrie Diaries, Wil Ohmsford in The Shannara Chronicles, and Elvis Presley in the biographical musical drama film Elvis.", new DateTime(1991, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Austin_Butler.jpg", "Austin Butler" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a54cf13-1fde-4537-a977-e1d0c85c3fb0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b08f852-2616-4d66-879b-9293207bcbad", "AQAAAAEAACcQAAAAEJtg9Mq4bndaXRAOCuWwsbJcXuVN6UFSPcHhQxlotKBq/rNcwH2sPyDbZURIArgvtw==", "6e521b5f-94ab-463e-af0d-b8c387a78cfa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90019873-1aef-4c52-bfff-71daa57dde4f", "AQAAAAEAACcQAAAAEICNW7cX5eLAvIVbV67QqBRj8Y0VWq7kEaFwJUmqgzSayKG933xEjSUqTxc4sUsGug==", "3dd1ebb2-7016-45c7-9d74-6287a4552ab7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd5cc46a-ef03-4222-ad12-71572e2c61ba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70acb552-4e05-4874-9d7a-7c47299fb6db", "AQAAAAEAACcQAAAAEMRpCivt0zdr0kjV/cmy3QWas2Izk6bnVKwvD/3Bcwd9fD6g1GZmJq6XAEv9ST68vw==", "977a7ca3-0554-4c46-9fd7-a6a09ade23df" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Biography", "BirthDate", "ImageUrl", "Name" },
                values: new object[] { 2, "Denis Villeneuve is a Canadian film director, writer, and producer. He is a four-time recipient of the Canadian Screen Award for Best Direction, for Maelström in 2001, Polytechnique in 2009, Incendies in 2011, and Enemy in 2013. The first three of these films also won the Canadian Screen Award for Best Motion Picture, while the latter was awarded the prize for best Canadian film of the year by the Toronto Film Critics Association. The first feature film he directed is Un 32 août sur terre, which was selected as the Canadian entry for the Best Foreign Language Film at the 68th Academy Awards, but was not accepted as a nominee. He was later nominated three times for the Academy Award for Best Director, for the films Arrival (2016), Blade Runner 2049 (2017), and Dune (2021).", new DateTime(1967, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/directors/Denis_Villeneuve.jpg", "Denis Villeneuve" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DirectorId", "Duration", "ImageUrl", "ReleaseDate", "Title" },
                values: new object[] { 3, "Dune: Part Two is an upcoming American epic science fiction film directed by Denis Villeneuve and written by Jon Spaihts, Villeneuve, and Eric Roth. It is the second of a planned two-part adaptation of the 1965 novel of the same name by Frank Herbert, and will cover the second half of the book. The film stars an ensemble cast including Timothée Chalamet, Rebecca Ferguson, Oscar Isaac, Josh Brolin, Stellan Skarsgård, Dave Bautista, Stephen McKinley Henderson, Zendaya, David Dastmalchian, Chang Chen, Sharon Duncan-Brewster, Charlotte Rampling, Jason Momoa, and Javier Bardem.", 2, 166, "/images/movies/Dune_Part_Two.jpg", new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dune: Part Two" });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 11, 3 },
                    { 12, 3 },
                    { 13, 3 },
                    { 14, 3 },
                    { 15, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a54cf13-1fde-4537-a977-e1d0c85c3fb0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cc987b6-2c01-4d1a-a12f-5f4502442fbd", "AQAAAAEAACcQAAAAECk6bPDIgZu6wnVGiPO4J6ncetOCcqLMfpBkrXwHeg6arXy+gtjE8EaLXBypxd5NVg==", "ed86534a-c03b-46e2-aa63-b8c288ba12e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ab5df31-cc76-4e48-8a09-3cdae51a1494", "AQAAAAEAACcQAAAAEF+haMlMQASc3GLVFOTxAk4meY0S01puUXiFVM+uH35es0ok6wbXko9gZCK+CC3PJw==", "a47037a1-a496-461e-b640-18c2eee76eb2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd5cc46a-ef03-4222-ad12-71572e2c61ba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6eed808a-9b2b-4e95-af84-623eb7b2921d", "AQAAAAEAACcQAAAAEM8GvLk7UHNN7HopTBoaALYsxmVpG8uvqdgt/KbkIP8Sw0jsJ4Yf1Gyz6u6Qg1qeCg==", "2de954df-1603-4d52-8310-fd2fc62ab9fc" });
        }
    }
}
