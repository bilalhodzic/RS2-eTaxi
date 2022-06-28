using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class updatedvehicleclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserDriverId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "AirBag",
                table: "Vehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PricePerKm",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Transmission",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e344fb04-ad1d-42c3-8eea-ea31ed4de0ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a2c61744-3ab5-463a-bbaa-e8a8b9118b90");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "8198fb29-dc6a-4058-a91f-1fee622f3828");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "c43f457d-295f-42a3-b731-80e71aa7596d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f295ea7-4b27-4898-9562-c0988b9c249d", "AQAAAAEAACcQAAAAEKYkBRiL8RBq3DzObJDg2pq4/IUp5Onl1dB2/gDFhMzd3YL6FRztgMZpLYenQC/lVQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserCreatedTime" },
                values: new object[] { "45441713-324e-4fac-8daa-21c35db31a3f", "AQAAAAEAACcQAAAAENJBJiVQuAO1jUv0WH76/0y/FAkMz/YBcIIEZSkGUpQAMMJxw0tVVF1+G8Haoxy9lQ==", new DateTime(2022, 6, 28, 22, 15, 45, 816, DateTimeKind.Local).AddTicks(2131) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserCreatedTime" },
                values: new object[] { "3934d696-92ab-4501-9102-a97bef262db3", "AQAAAAEAACcQAAAAEArc2TAxXpHAFoobdQh/gwnXIgqKkx00VLJspaJrMv01rCxQtYUqcmgMGyOZ14xs5Q==", new DateTime(2022, 6, 28, 22, 15, 45, 824, DateTimeKind.Local).AddTicks(2976) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "29a0d6f3-6fa3-470f-b23f-3aa74cf663db", "AQAAAAEAACcQAAAAEJzOFXU7lTQ16Ba9JnhOCm7HQ2GOXFTzvmffJwzzlf2JyqLHe+4yVq14K2BLebho7g==" });

            migrationBuilder.CreateIndex(
                name: "IX_Files_VehicleId",
                table: "Files",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Vehicles_VehicleId",
                table: "Files",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Vehicles_VehicleId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_VehicleId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "AirBag",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "PricePerKm",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Transmission",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Files");

            migrationBuilder.AlterColumn<int>(
                name: "UserDriverId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "16f09109-a7a8-4a3f-bf83-84735ecd6c7d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "aecbec9b-3f9b-4302-b4ed-339c6260ebd5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "b26aeb23-6f8a-4b73-8aae-0fb671076209");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "7f72409e-cc6d-4a78-8ab5-4b1bafc64a26");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "768b9944-4fe2-4c3c-ab9d-289eea52c2e5", "AQAAAAEAACcQAAAAELvXWRUW0bxjwsLMvUB326M23krZXAWDGzABeofiB5r3nb6Gt9KSCi15JUDWr309ow==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserCreatedTime" },
                values: new object[] { "fe8e944f-0034-4d04-bf75-711b80bbf651", "AQAAAAEAACcQAAAAEAzVlxIEkvEQgd/LxkQAR8yKuYxhgO9A7etvwpcuezqt5oIEGj3XVkBMK6NWVSL8fw==", new DateTime(2022, 6, 28, 19, 4, 2, 739, DateTimeKind.Local).AddTicks(8563) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserCreatedTime" },
                values: new object[] { "c3df0582-99fa-4bfd-a581-9096af76167b", "AQAAAAEAACcQAAAAEBeFu918MVxf6otPOyQUqaHyf8kTaUT3UT9CbP+c+LK3O7Nt1CHIeS5bEY3KrHtzfg==", new DateTime(2022, 6, 28, 19, 4, 2, 777, DateTimeKind.Local).AddTicks(8256) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "32524001-c3b3-42ac-8765-c93e097fe48f", "AQAAAAEAACcQAAAAEJpfNoq5lqvjE4wXozgyKE8l+aDfRkyTZO++i78TsW28m70xMlP7VhPpeGd01rWtug==" });
        }
    }
}
