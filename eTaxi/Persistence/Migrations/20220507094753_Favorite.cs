using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Favorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FavoritesId",
                table: "Favorites",
                newName: "FavoriteId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6fd97032-6f09-412b-9e40-2c2bb0550b8e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "11023fb3-4b95-4bed-879a-73c411b034d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "20076af1-a24a-40dd-b17d-405324a6e74b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "8add544f-9ca9-4112-88d5-7aa6430b9c35");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "58abde35-efdd-421b-9c90-70fd5d915593", "AQAAAAEAACcQAAAAEPvuKkxvu5Xn/oA42WAVtUITNW9KYZvNRBQ0rBhp6q1qJK7e+FlVhyKeX6AQRsSPPA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserCreatedTime" },
                values: new object[] { "b96faa45-603a-45e3-8010-2661698ec4ab", "AQAAAAEAACcQAAAAEFifCkcxt9cp9FBPo8WhdTTazRnAcDyzkxrycgTs3ObwsCx4944yFcoQdmyhBVRkLg==", new DateTime(2022, 5, 7, 11, 47, 52, 899, DateTimeKind.Local).AddTicks(9621) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserCreatedTime" },
                values: new object[] { "21a7dc49-0c5f-49c3-87f4-11b6895a858f", "AQAAAAEAACcQAAAAEFfWMIX+gs2Swi1FXFw+tOJVZ82+a7+aa5mEVnG0lSLem+G5x7loDBNMQI7wkApmKA==", new DateTime(2022, 5, 7, 11, 47, 52, 907, DateTimeKind.Local).AddTicks(2354) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "874485d6-4c9c-43b1-9442-f3c369ad0dc1", "AQAAAAEAACcQAAAAEIyw9xxAyl1qw2UGXetRcHMZSF30zNRGAXQimERZquN27GTGAEJwrxkJELhQ28rhnA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FavoriteId",
                table: "Favorites",
                newName: "FavoritesId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a0961e94-356a-449e-8def-942678b0649d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4c8dee7f-ce63-492c-930d-b3a13185bd09");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "dad71f22-c30d-4edc-b7a1-799e7a9c8398");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "fbb9c20a-658d-4679-ab0b-73c3e9bcf9a5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "87ce33e1-2a4e-4638-b763-9ea292887289", "AQAAAAEAACcQAAAAEI7tA8I0iTkIH3CpqLM1fPXltVUxXQa9aL7gHVAsIwa6PSK6KywTFqmdPiU0r0jHDg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserCreatedTime" },
                values: new object[] { "b9485347-fd50-4abd-b851-456192a463a5", "AQAAAAEAACcQAAAAEAwi+zyUKD0KR1bKsDaPwL6Ly1AaqZGy6/tiDLhtX9Csny5azYyLptyUPkHTMGirkQ==", new DateTime(2022, 5, 7, 9, 4, 30, 16, DateTimeKind.Local).AddTicks(6950) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserCreatedTime" },
                values: new object[] { "1b499bdd-c5e3-4242-a363-d131206e7855", "AQAAAAEAACcQAAAAEBtHjCC5v2oKz2DnGiQS5oIm9dskPyfAuAeIPGRfc5YOoMEI0fcRo7Syab+31ezNFw==", new DateTime(2022, 5, 7, 9, 4, 30, 23, DateTimeKind.Local).AddTicks(6015) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "766d2673-4c0f-4bd8-90cd-dfbd0a72f39b", "AQAAAAEAACcQAAAAEPmlizdLKj2aeUXAKmiy/aZC0xAg8wvoApKiLZZi3TKkk7LFIsZdLAffKm5CB6fjgw==" });
        }
    }
}
