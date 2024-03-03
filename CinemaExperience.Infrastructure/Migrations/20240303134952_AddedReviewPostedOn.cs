using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaExperience.Infrastructure.Migrations
{
    public partial class AddedReviewPostedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostedOn",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "The date when the review was posted");

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
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "PostedOn",
                value: new DateTime(2021, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "PostedOn",
                value: new DateTime(2021, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "PostedOn",
                value: new DateTime(2021, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "PostedOn",
                value: new DateTime(2021, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedOn",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a54cf13-1fde-4537-a977-e1d0c85c3fb0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31b7d67e-9d1b-46de-adff-06c54522952c", "AQAAAAEAACcQAAAAENheOer2og2HLYncOpBjBXxHtZwpm4Trnfp+PIGZFNmsRTha+U7HoXzcaSuaeYS3yQ==", "4708e541-a554-4839-beb6-514e8db3f69b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ddac0c8-5b4a-4ac9-9346-08f6dc133ca5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a55ab0e3-07c2-46e0-b32d-2da5547ab759", "AQAAAAEAACcQAAAAEEme592brLLvcuoG50jZs5YDtJfL8A1msAcdlN0EqpEyb89I/aK5EueS0Wol7kn5fw==", "a9834d79-1267-46ed-b082-354743a1e346" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd5cc46a-ef03-4222-ad12-71572e2c61ba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "521107b2-9b33-45e1-886c-74b7413384ee", "AQAAAAEAACcQAAAAEA0MIgSI3KCyjbLtQPzWfU5Dd4++BWAwu+jxFUN2PWxyiDg1OsQ/o+zggBkXYy2GjA==", "d5b66543-f7d0-4905-990f-a477c3431fb4" });
        }
    }
}
