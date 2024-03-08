using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaExperience.Infrastructure.Migrations
{
    public partial class RemovedIsCriticInReviewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCriticReview",
                table: "Reviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCriticReview",
                table: "Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Distinguishes between regular user and critic review");
        }
    }
}
