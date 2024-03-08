using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaExperience.Infrastructure.Migrations
{
    public partial class SeededDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Biography", "BirthDate", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Christian Charles Philip Bale is an English actor. Known for his versatility and intensive method acting, he is the recipient of many awards, including an Academy Award and two Golden Globe Awards. Time magazine included him on its list of the 100 most influential people in the world in 2011. Born in Haverfordwest, Wales, to English parents, Bale had his first starring role at age 13 in Steven Spielberg's war film Empire of the Sun (1987).", new DateTime(1974, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Christian_Bale.jpg", "Christian Bale" },
                    { 2, "Heath Andrew Ledger was an Australian actor and music video director. After performing roles in several Australian television and film productions during the 1990s, Ledger left for the United States in 1998 to further develop his film career. His work comprised nineteen films, including 10 Things I Hate About You (1999), The Patriot (2000), A Knight's Tale (2001), Monster's Ball (2001), Lords of Dogtown (2005), Brokeback Mountain (2005), Candy (2006), I'm Not There (2007), The Dark Knight (2008), and The Imaginarium of Doctor Parnassus (2009).", new DateTime(1979, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Heath_Ledger.jpg", "Heath Ledger" },
                    { 3, "Aaron Edward Eckhart is an American actor. Born in Cupertino, California, Eckhart moved to England at age 13, when his father relocated the family. Several years later, he began his acting career by performing in school plays, before moving to Sydney, Australia, for his high school senior year. He left high school without graduating, but earned a diploma through an adult education course, and graduated from Brigham Young University (BYU) in 1994 with a Bachelor of Fine Arts degree in film.", new DateTime(1968, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Aaron_Eckhart.jpg", "Aaron Eckhart" },
                    { 4, "Sir Michael Caine CBE is an English actor. Known for his distinctive Cockney accent, he has appeared in more than 130 films during a career spanning over 70 years, and is considered a British film icon. As of February 2017, the films in which Caine has appeared have grossed over $7.8 billion worldwide. Often playing a Cockney, Caine made his breakthrough in the 1960s with starring roles in British films, including Zulu (1964), The Ipcress File (1965), Alfie (1966), for which he was nominated for an Academy Award, The Italian Job (1969), and Battle of Britain (1969).", new DateTime(1933, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Michael_Caine.jpg", "Michael Caine" },
                    { 5, "Margalit Ruth Gyllenhaal is an American actress and film producer. Part of the Gyllenhaal family, she is the daughter of filmmakers Stephen Gyllenhaal and Naomi Achs, and the older sister of actor Jake Gyllenhaal. She began her career as a teenager with small roles in several of her father's films, and appeared with her brother in the cult favorite Donnie Darko (2001). She received critical acclaim for her leading roles in the independent films Secretary (2002) and Sherrybaby (2006), earning a Golden Globe Award for the latter.", new DateTime(1977, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Maggie_Gyllenhaal.jpg", "Maggie Gyllenhaal" },
                    { 6, "Leonardo Wilhelm DiCaprio is an American actor, film producer, and environmentalist. Known for his work in biopics and period films, DiCaprio is the recipient of numerous accolades, including an Academy Award, a British Academy Film Award, and three Golden Globe Awards. As of 2019, his films have grossed over $7.2 billion worldwide, and he has been placed eight times in annual rankings of the world's highest-paid actors.", new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Leonardo_DiCaprio.jpg", "Leonardo DiCaprio" },
                    { 7, "Joseph Leonard Gordon-Levitt is an American actor, filmmaker, singer, and entrepreneur. As a child, Gordon-Levitt appeared in the films A River Runs Through It, Angels in the Outfield, Holy Matrimony and 10 Things I Hate About You, and as Tommy Solomon in the TV series 3rd Rock from the Sun. He took a break from acting to study at Columbia University, but dropped out in 2004 to pursue acting again. He has since starred in (500) Days of Summer, Inception, Hesher, 50/50, Premium Rush, The Night Before, and Snowden.", new DateTime(1981, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Joseph_Gordon_Levitt.jpg", "Joseph Gordon-Levitt" },
                    { 8, "Elliot Page is a Canadian actor and producer. He first became known for his role in the film and television series Pit Pony (1997–2000), for which he won a Young Artist Award, and for recurring roles in Trailer", new DateTime(1987, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Elliot_Page.jpg", "Elliot Page" },
                    { 9, "Edward Thomas Hardy CBE is an English actor and producer. After studying acting at the Drama Centre London, he made his film debut in Ridley Scott's Black Hawk Down (2001) and has since appeared in such films as Star Trek: Nemesis (2002), RocknRolla (2008), Bronson (2008), Warrior (2011), Tinker Tailor Soldier Spy (2011), Lawless (2012), Locke (2013), The Drop (2014), and The Revenant (2015), for which he received a nomination for the Academy Award for Best Supporting Actor.", new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Tom_Hardy.jpg", "Tom Hardy" },
                    { 10, "Ken Watanabe is a Japanese actor. To English-speaking audiences, he is known for playing tragic hero characters, such as General Tadamichi Kuribayashi in Letters from Iwo Jima and Lord Katsumoto Moritsugu in The Last Samurai, for which he was nominated for the Academy Award for Best Supporting Actor. Among other awards, he has won the Japan Academy Film Prize for Best Actor twice, in 2007 for Memories of Tomorrow and in 2010 for Shizumanu Taiyō. He is also known for his roles in Christopher Nolan's Batman Begins and The Dark Knight (as Ra's al Ghul), Inception, and Godzilla.", new DateTime(1959, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "/images/actors/Ken_Watanabe.jpg", "Ken Watanabe" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "IsCritic", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2a54cf13-1fde-4537-a977-e1d0c85c3fb0", 0, "31b7d67e-9d1b-46de-adff-06c54522952c", "ApplicationUser", "admin@admin.com", false, "Admin", true, false, "Admin", false, null, "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAENheOer2og2HLYncOpBjBXxHtZwpm4Trnfp+PIGZFNmsRTha+U7HoXzcaSuaeYS3yQ==", null, false, "4708e541-a554-4839-beb6-514e8db3f69b", false, "admin@admin.com" },
                    { "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5", 0, "a55ab0e3-07c2-46e0-b32d-2da5547ab759", "ApplicationUser", "guest@guest.com", false, "Todor", false, false, "Kuzmanov", false, null, "guest@guest.com", "guest@guest.com", "AQAAAAEAACcQAAAAEEme592brLLvcuoG50jZs5YDtJfL8A1msAcdlN0EqpEyb89I/aK5EueS0Wol7kn5fw==", null, false, "a9834d79-1267-46ed-b082-354743a1e346", false, "guest@guest.com" },
                    { "cd5cc46a-ef03-4222-ad12-71572e2c61ba", 0, "521107b2-9b33-45e1-886c-74b7413384ee", "ApplicationUser", "critic@critic.com", false, "Teodora", false, true, "Kuzmanova", false, null, "critic@critic.com", "critic@critic.com", "AQAAAAEAACcQAAAAEA0MIgSI3KCyjbLtQPzWfU5Dd4++BWAwu+jxFUN2PWxyiDg1OsQ/o+zggBkXYy2GjA==", null, false, "d5b66543-f7d0-4905-990f-a477c3431fb4", false, "critic@critic.com" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Biography", "BirthDate", "ImageUrl", "Name" },
                values: new object[] { 1, "Christopher Edward Nolan CBE is a British-American film director, producer, and screenwriter. His films have grossed over US$5 billion worldwide, and he is one of the highest-grossing directors in history. Having made his directorial debut with Following (1998), Nolan gained considerable attention for his second feature, Memento (2000), for which he received a nomination for the Academy Award for Best Original Screenplay. The acclaim garnered by his independent films gave Nolan the opportunity to make the big-budget thriller Insomnia (2002), and the mystery drama The Prestige (2006). He found further popular and critical success with The Dark Knight Trilogy (2005–2012), Inception (2010), Interstellar (2014), Dunkirk (2017), and Tenet (2020).", new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://commons.wikimedia.org/wiki/Category:Christopher_Nolan#/media/File:Christopher_Nolan_Cannes_2018.jpg", "Christopher Nolan" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Science" },
                    { 3, "Drama" },
                    { 4, "Thriller" },
                    { 5, "Crime" },
                    { 6, "Sci-Fi" },
                    { 7, "Mystery" },
                    { 8, "Adventure" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CriticsRating", "Description", "DirectorId", "Duration", "ImageUrl", "ReleaseDate", "Title", "UserRating" },
                values: new object[] { 1, 0, "Inception is a 2010 science fiction action film written and directed by Christopher Nolan, who also produced the film with Emma Thomas, his wife. The film stars Leonardo DiCaprio as a professional thief who steals information by infiltrating the subconscious of his targets. He is offered a chance to have his criminal history erased as payment for the implantation of another person's idea into a target's subconscious. The ensemble cast includes Ken Watanabe, Joseph Gordon-Levitt, Marion Cotillard, Elliot Page, Tom Hardy, Dileep Rao, Cillian Murphy, Tom Berenger, and Michael Caine.", 1, 148, "/images/movies/inception.jpg", new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception", 0 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CriticsRating", "Description", "DirectorId", "Duration", "ImageUrl", "ReleaseDate", "Title", "UserRating" },
                values: new object[] { 2, 0, "The Dark Knight is a 2008 superhero film directed, produced, and co-written by Christopher Nolan. Based on the DC Comics character Batman, the film is the second installment of Nolan's The Dark Knight Trilogy and a sequel to 2005's Batman Begins, starring Christian Bale and supported by Michael Caine, Heath Ledger, Gary Oldman, Aaron Eckhart, Maggie Gyllenhaal, and Morgan Freeman. In the film, Bruce Wayne / Batman (Bale), Police Lieutenant James Gordon (Oldman) and District Attorney Harvey Dent (Eckhart) form an alliance to dismantle organized crime in Gotham City, but are menaced by an anarchistic mastermind known as the Joker (Ledger), who seeks to undermine Batman's influence and throw the city into anarchy.", 1, 152, "/images/movies/The_Dark_Knight.jpg", new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight", 0 });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 1, 2 },
                    { 8, 2 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "MovieId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1, "It is, simply put, a cerebral masterpiece from Christopher Nolan.", 1, 10, "cd5cc46a-ef03-4222-ad12-71572e2c61ba" },
                    { 2, "The famous masked vigilante has never looked or felt more intense.", 2, 7, "cd5cc46a-ef03-4222-ad12-71572e2c61ba" },
                    { 3, "Mind-blowing, amazing, smart, thrilling. That's all", 1, 10, "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5" },
                    { 4, "Revolutionized the superhero genre. Must see.", 2, 8, "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a54cf13-1fde-4537-a977-e1d0c85c3fb0");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd5cc46a-ef03-4222-ad12-71572e2c61ba");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
