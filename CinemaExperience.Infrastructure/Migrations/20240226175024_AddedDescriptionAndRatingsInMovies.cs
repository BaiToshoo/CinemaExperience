using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaExperience.Infrastructure.Migrations
{
    public partial class AddedDescriptionAndRatingsInMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CriticsRating",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The rating of the movie by critics");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                comment: "The description of the movie");

            migrationBuilder.AddColumn<int>(
                name: "UserRating",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The rating of the movie by users");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriticsRating",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UserRating",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "AspNetUsers");
        }
    }
}
