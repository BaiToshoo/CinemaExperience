using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaExperience.Infrastructure.Migrations
{
    public partial class RemovedRatingInMovieModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriticsRating",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UserRating",
                table: "Movies");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CriticsRating",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The rating of the movie by critics");

            migrationBuilder.AddColumn<int>(
                name: "UserRating",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The rating of the movie by users");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a54cf13-1fde-4537-a977-e1d0c85c3fb0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "098d67f9-50a2-4db0-9732-aa70201e9293", "AQAAAAEAACcQAAAAEBaka5WS+Ct9I8S8sNVZzRA86oRHhPAuPOd+MyGTnU8jkk4WcSPOHesHgOi/qr1seA==", "ce081a93-28da-4a29-adae-0a56dc6155b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcff82d8-3f44-4bc0-b97b-3d4d26361c82", "AQAAAAEAACcQAAAAEBqjAgy5ahEdjcbKgaFYAaayy+H+6zPeJqQkLYs1r9DoLWMVpOAGbbjtpciXZ7j/bQ==", "3f3deb1f-a5fb-4974-afb1-5f6379009259" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd5cc46a-ef03-4222-ad12-71572e2c61ba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba44112e-eaa1-4014-9ddb-f9417a95eb9c", "AQAAAAEAACcQAAAAEBLW+oWpoRQ7Rmxqu/Y81T6kBtomL/YQZKzuB6IdCX/weWvsxkEoExtRcI49DJk05Q==", "7f42b160-fb47-4d45-abc7-dac131d431cc" });
        }
    }
}
