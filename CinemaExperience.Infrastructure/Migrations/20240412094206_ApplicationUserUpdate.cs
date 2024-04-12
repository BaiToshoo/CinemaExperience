using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaExperience.Infrastructure.Migrations
{
    public partial class ApplicationUserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsCritic",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Directors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Actors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a54cf13-1fde-4537-a977-e1d0c85c3fb0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "151f5bff-ee94-4595-8456-260927df01cc", "AQAAAAEAACcQAAAAEMCrO2h1ephGgYyzqLiOSBdlUq9j+s8HbC2h2zieP8pRsTeDNPCtB011hyO4tS9HmQ==", "d83aa84b-943e-4514-ace8-590835021237" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fb88d97-73a8-4f6d-bc4a-bce518ef910d", "AQAAAAEAACcQAAAAECgzz0CqA5XfJP+QDFCyzbNV+A933ru+ewk/zPi6dwCBUOFSueT3z6Qhl9dtBpq5/w==", "347a44dd-612f-46f3-8d46-956a5abc5430" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd5cc46a-ef03-4222-ad12-71572e2c61ba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a380e7c-5234-4fe5-9f67-06426779e684", "AQAAAAEAACcQAAAAEOp5GOxrlFDLwJSoLB+khM8MyA9w+GjJh+jscvD+5/j3g4iTjmTcyqiszb0vIqDN9g==", "f972f591-250c-4b7b-88b5-51dc169423b7" });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 6, 3 },
                    { 8, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenreId", "MovieId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Directors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCritic",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Actors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a54cf13-1fde-4537-a977-e1d0c85c3fb0",
                columns: new[] { "ConcurrencyStamp", "IsAdmin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b08f852-2616-4d66-879b-9293207bcbad", true, "AQAAAAEAACcQAAAAEJtg9Mq4bndaXRAOCuWwsbJcXuVN6UFSPcHhQxlotKBq/rNcwH2sPyDbZURIArgvtw==", "6e521b5f-94ab-463e-af0d-b8c387a78cfa" });

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
                columns: new[] { "ConcurrencyStamp", "IsCritic", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70acb552-4e05-4874-9d7a-7c47299fb6db", true, "AQAAAAEAACcQAAAAEMRpCivt0zdr0kjV/cmy3QWas2Izk6bnVKwvD/3Bcwd9fD6g1GZmJq6XAEv9ST68vw==", "977a7ca3-0554-4c46-9fd7-a6a09ade23df" });
        }
    }
}
