using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaExperience.Infrastructure.Migrations
{
    public partial class ImageUrlMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Directors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Actors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/directors/Christopher_Nolan.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a54cf13-1fde-4537-a977-e1d0c85c3fb0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a557560e-c17e-4ef3-913b-df4d8f2962d5", "AQAAAAEAACcQAAAAENd/7aL5juJ6Cc+dPMYODhu3ia8JsuZ9B6kdry7XAfhi0Uot0iVs7+bJrAz7xiJzKg==", "833bfdbb-1fe5-4c58-a24b-8f5de14544e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b629155b-e244-410d-b6c0-956bab5208d5", "AQAAAAEAACcQAAAAECcxK1Wua+4nnorQZWvFFQUahgr+YiiUgw5uF3u/60YV5ihMxHD3Jl1gpY0drEL/Fw==", "a9a6af44-c0fe-4e1f-83f2-9e9423323fae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd5cc46a-ef03-4222-ad12-71572e2c61ba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bcb014e-8a78-4c3a-8810-090ab2ff8427", "AQAAAAEAACcQAAAAEKQQdnQ2qv5IPxKSOfmgF75PloNze71D2pLbSlL9hMI3yITHQZ8Zl/BjZiaOKTMz2Q==", "c2777b1a-9906-4805-b1b6-c1897233509e" });

            migrationBuilder.UpdateData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://commons.wikimedia.org/wiki/Category:Christopher_Nolan#/media/File:Christopher_Nolan_Cannes_2018.jpg");
        }
    }
}
