using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaExperience.Infrastructure.Migrations
{
    public partial class MoreSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a54cf13-1fde-4537-a977-e1d0c85c3fb0",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c76dcd6-0928-48f5-8c5e-dc49871b5e5e", "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEP0YjN2ikje4e4AMiGlQry5LtNh0dr5qOLE7K8mfnH4Cm60xgI9XbSNrAkJv3pDM6w==", "74d3a3b5-80dc-411b-b973-223c2890e007" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6689f3b3-e209-4b81-9a3d-b5cb23645699", "GUEST@GUEST.COM", "GUEST@GUEST.COM", "AQAAAAEAACcQAAAAENuAL4gYPJz/AzmLzfBC5fYyweZq42BTF9JWyRvBRQGC6jouInMH58QW82nkQhyPZg==", "21cbe1d0-8f47-44d8-9d0e-d72a760952b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd5cc46a-ef03-4222-ad12-71572e2c61ba",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf7e050e-72be-4eaa-bc87-84dbbc03cea7", "CRITIC@CRITIC.COM", "CRITIC@CRITIC.COM", "AQAAAAEAACcQAAAAELacJeHuTsiaSALEEmkYrhtmyNISuWPZcldJdjAa+9NgGGZZbwhFT3AjxFbki2b+Mg==", "a49f725b-148e-4a28-b46d-dca0cd36575c" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5ed4fe5a-5f46-4223-bcd5-49e1263b4182", 0, "55c0888e-15db-4d0e-a80e-b6969e7031d0", "ApplicationUser", "dwight@brown.com", false, "Dwight", "Brown", false, null, "DWIGHT@BROWN.COM", "DWIGHT@BROWN.COM", "AQAAAAEAACcQAAAAEI3aNa1ke5ze5yIbY1F0jtpc3ZXZV+4aGNk0lcjKC5vMrGvdwYzZZADFtROZhkNdyA==", null, false, "6dbd6d64-1866-4f1c-9f4a-4a60e933bfda", false, "dwight@brown.com" },
                    { "f4320fef-5953-4193-8c9e-4b72f71873ab", 0, "d7dc129c-8e5c-4217-8047-7f7f193fae89", "ApplicationUser", "kimberly@pierce.com", false, "Kimberly", "Pierce", false, null, "KIMBERLY@PIERCE.COM", "KIMBERLY@PIERCE.COM", "AQAAAAEAACcQAAAAEARCR4gPQcAvq03b4DuIrULv3zFQJbxkq0oomfNuWB61cat7xTN6hqhcztBtFaFsgw==", null, false, "eb82e708-06be-4866-81d1-9a21bfbc6ade", false, "kimberly@pierce.com" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "MovieId", "PostedOn", "Rating", "UserId" },
                values: new object[,]
                {
                    { 5, "An epic and spectacular sci-fi allegory with mass appeal.", 3, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "5ed4fe5a-5f46-4223-bcd5-49e1263b4182" },
                    { 6, "The best movie of the year. A must-see.", 3, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "f4320fef-5953-4193-8c9e-4b72f71873ab" },
                    { 7, "This film must be revisited, talked about, analyzed, and rewatched again and again. It will surely grow upon each viewing, but it proves instantly enthralling the first time.", 1, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "f4320fef-5953-4193-8c9e-4b72f71873ab" },
                    { 8, "The Dark Knight is a film that is not only a great comic book movie, but a great movie in general. It's a film that transcends the superhero genre and is a film that will be remembered for years to come.", 2, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "5ed4fe5a-5f46-4223-bcd5-49e1263b4182" },
                    { 9, "The Dark Knight is a film that is not only a great comic book movie, but a great movie in general. It's a film that transcends the superhero genre and is a film that will be remembered for years to come.", 2, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "f4320fef-5953-4193-8c9e-4b72f71873ab" },
                    { 10, "When you have such a great writer/director as Christopher Nolan making his own thing, you can only expect to be mindblown. And I was, but not in the good way. I was blown", 1, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "5ed4fe5a-5f46-4223-bcd5-49e1263b4182" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ed4fe5a-5f46-4223-bcd5-49e1263b4182");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f4320fef-5953-4193-8c9e-4b72f71873ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a54cf13-1fde-4537-a977-e1d0c85c3fb0",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "151f5bff-ee94-4595-8456-260927df01cc", "admin@admin.com", "admin@admin.com", "AQAAAAEAACcQAAAAEMCrO2h1ephGgYyzqLiOSBdlUq9j+s8HbC2h2zieP8pRsTeDNPCtB011hyO4tS9HmQ==", "d83aa84b-943e-4514-ace8-590835021237" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fb88d97-73a8-4f6d-bc4a-bce518ef910d", "guest@guest.com", "guest@guest.com", "AQAAAAEAACcQAAAAECgzz0CqA5XfJP+QDFCyzbNV+A933ru+ewk/zPi6dwCBUOFSueT3z6Qhl9dtBpq5/w==", "347a44dd-612f-46f3-8d46-956a5abc5430" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd5cc46a-ef03-4222-ad12-71572e2c61ba",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a380e7c-5234-4fe5-9f67-06426779e684", "critic@critic.com", "critic@critic.com", "AQAAAAEAACcQAAAAEOp5GOxrlFDLwJSoLB+khM8MyA9w+GjJh+jscvD+5/j3g4iTjmTcyqiszb0vIqDN9g==", "f972f591-250c-4b7b-88b5-51dc169423b7" });
        }
    }
}
