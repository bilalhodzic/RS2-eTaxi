using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class addedhubclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Vehicles_VehicleId1",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_VehicleId1",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FormattedAddress",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "VehicleId1",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "Radius",
                table: "Locations",
                newName: "Address");

            migrationBuilder.CreateTable(
                name: "Hubs",
                columns: table => new
                {
                    HubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hubs", x => x.HubId);
                    table.ForeignKey(
                        name: "FK_Hubs_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9a317257-794a-4113-bceb-2eb12e58b053");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "bc547526-6450-4c61-b8a4-c05fa56ee261");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "2aa43886-c08f-45c6-b91b-d3a43dbcf087");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "3f79da63-3cff-4ca6-a668-b10c8b389866");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e6e0ce6c-7c4b-42ad-b152-7c0524ecebba", "AQAAAAEAACcQAAAAEBqCyPrAbu1BBwgNAfYnZyUjDrDBvtOItcs82WBbQ8oaNM+JPIwo5bidxEzsvSuyCQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserCreatedTime" },
                values: new object[] { "09214bf6-691e-4479-87b1-eab010e86f62", "AQAAAAEAACcQAAAAEMwMB6t9mwd+11UvpEfBdRviW6ywCjZYnyfJzVDlYoe+ywIatZ82ypKEUUFgOLJvzA==", new DateTime(2022, 6, 30, 9, 22, 41, 130, DateTimeKind.Local).AddTicks(1611) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserCreatedTime" },
                values: new object[] { "295d2479-273c-4e8a-8582-832fc152e75b", "AQAAAAEAACcQAAAAEHtv0hgJICx6AX7CiU25TmcSVy94aNERgIW74iDdDYYkTcHgf2/qfhII32v6fCnEdQ==", new DateTime(2022, 6, 30, 9, 22, 41, 147, DateTimeKind.Local).AddTicks(5648) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4ff8cf68-2fe9-4da4-9b33-93af6de1675f", "AQAAAAEAACcQAAAAEE4A1Kk2wmiIi+e8+f/lIzqniY20/A8qCj93ahxQ847+WsY2/jkALLBPGmu4rlmUkA==" });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "FileId", "FileName", "OriginalName", "Type", "Url", "UserId", "VehicleId" },
                values: new object[,]
                {
                    { 1, "189400dc-e58e-42c6-9d77-6564969c2f66_car.png", "car.png", "CarIcon", "Resources/189400dc-e58e-42c6-9d77-6564969c2f66_car.png", 1, null },
                    { 2, "e96c66e4-929e-4369-9b93-2562062fbfa6_cady.png", "car.png", "CarIcon", "Resources/e96c66e4-929e-4369-9b93-2562062fbfa6_cady.png", 1, null },
                    { 3, "321f8965-2139-4abe-b164-0d5cdd681516_SUV.png", "SUV.png", "CarIcon", "Resources/321f8965-2139-4abe-b164-0d5cdd681516_SUV.png", 1, null },
                    { 4, "9e889e03-c086-408f-8647-9637292659b5_sedan.png", "sedan.png", "CarIcon", "Resources/9e889e03-c086-408f-8647-9637292659b5_sedan.png", 1, null },
                    { 5, "33ed6c0b-fee1-4ba9-a5e5-a4e59e775233_Bus.png", "bus.png", "CarIcon", "Resources/33ed6c0b-fee1-4ba9-a5e5-a4e59e775233_Bus.png", 1, null }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "VehicleTypeId", "FileId", "NumberOfSeats", "Type" },
                values: new object[,]
                {
                    { 1, 1, 5, "Hatchback" },
                    { 2, 2, 5, "Mini van" },
                    { 3, 3, 5, "SUV" },
                    { 4, 4, 5, "Sedan" },
                    { 5, 5, 40, "Bus" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "AirBag", "AirCondition", "Brand", "Color", "CreatedTime", "CurrentLocationId", "FuelType", "KmTraveled", "LicenceNumber", "Name", "PricePerKm", "Transmission", "TypeId", "UserDriverId", "UserId", "Year" },
                values: new object[] { 4, true, true, "Golf", "Siva", new DateTime(2022, 6, 30, 9, 22, 41, 162, DateTimeKind.Local).AddTicks(2194), 1, "Benzin", 2345.0, "a455-65767", "Golf 7", 0, "Manual", 1, 0, null, 2019 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "AirBag", "AirCondition", "Brand", "Color", "CreatedTime", "CurrentLocationId", "FuelType", "KmTraveled", "LicenceNumber", "Name", "PricePerKm", "Transmission", "TypeId", "UserDriverId", "UserId", "Year" },
                values: new object[] { 5, true, true, "Audi", "Siva", new DateTime(2022, 6, 30, 9, 22, 41, 162, DateTimeKind.Local).AddTicks(7520), 1, "Benzin", 13345.0, "a455-65768", "Audi A8", 0, "Automatic", 4, 0, null, 2020 });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "AirBag", "AirCondition", "Brand", "Color", "CreatedTime", "CurrentLocationId", "FuelType", "KmTraveled", "LicenceNumber", "Name", "PricePerKm", "Transmission", "TypeId", "UserDriverId", "UserId", "Year" },
                values: new object[] { 6, true, true, "Skoda", "Crna", new DateTime(2022, 6, 30, 9, 22, 41, 162, DateTimeKind.Local).AddTicks(7785), 1, "Benzin", 13245.0, "a455-65769", "Skoda superb", 0, "Manual", 4, 0, null, 2019 });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "FileId", "FileName", "OriginalName", "Type", "Url", "UserId", "VehicleId" },
                values: new object[] { 8, "https://res.cloudinary.com/doswamdah/image/upload/v1656523879/rs2/golf_7_didjje.jpg", "golf.png", "Car", "https://res.cloudinary.com/doswamdah/image/upload/v1656523879/rs2/golf_7_didjje.jpg", 1, 4 });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "FileId", "FileName", "OriginalName", "Type", "Url", "UserId", "VehicleId" },
                values: new object[] { 7, "https://res.cloudinary.com/doswamdah/image/upload/v1656523883/rs2/audia8_gckbfh.png", "audi.png", "Car", "https://res.cloudinary.com/doswamdah/image/upload/v1656523883/rs2/audia8_gckbfh.png", 1, 5 });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "FileId", "FileName", "OriginalName", "Type", "Url", "UserId", "VehicleId" },
                values: new object[] { 6, "https://res.cloudinary.com/doswamdah/image/upload/v1656523885/rs2/skodasuperb_gluat1.png", "skoda.png", "Car", "https://res.cloudinary.com/doswamdah/image/upload/v1656523885/rs2/skodasuperb_gluat1.png", 1, 6 });

            migrationBuilder.CreateIndex(
                name: "IX_Hubs_LocationId",
                table: "Hubs",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hubs");

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "FileId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "FileId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "FileId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "FileId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "FileId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "FileId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleTypes",
                keyColumn: "VehicleTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "FileId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "FileId",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Locations",
                newName: "Radius");

            migrationBuilder.AddColumn<string>(
                name: "FormattedAddress",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId1",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4de68df3-7aea-40e6-bbc0-0e3c242a0940");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "37d4872e-14ca-4f10-bb08-45f8cbfd35a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "8d9b4d16-7d57-4dcf-8880-025ffc220ec3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "d7b330a6-a3fe-49ea-86fe-b4ffffe0e6d9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "37a2bcad-d215-41ca-be44-4d741ac93f53", "AQAAAAEAACcQAAAAEEMnRXiUFvV7SrICjxLM63vgeqkVk8aQSnfWUQcbt5OKIaY/jFi0uoDbFZwW6ta4rg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserCreatedTime" },
                values: new object[] { "793b29a9-f970-4c17-8356-fa5822a18e67", "AQAAAAEAACcQAAAAEChEBw6AAO44l8dGBivzpXriooif4CXJaBSraXic4d/UQmPlwlSwifleA7JTgSu7bQ==", new DateTime(2022, 6, 28, 22, 29, 56, 310, DateTimeKind.Local).AddTicks(3043) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserCreatedTime" },
                values: new object[] { "1a8e8a73-b649-45c2-ad11-72d79ecd8015", "AQAAAAEAACcQAAAAEINdxSLtdIJ/usdEqUqHacdT+hYuKM+06t1xiF/pnZWVfbKHqAT4xuyAmy5jpy2Kvg==", new DateTime(2022, 6, 28, 22, 29, 56, 325, DateTimeKind.Local).AddTicks(505) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9fdb776c-dc3c-4b7d-83cc-4fb94ef6b43e", "AQAAAAEAACcQAAAAEOlhs4XUWHGTyRydQ+JjM5n0jPzN5UH8y5uHgdlJNfKKa76Xi/7bTyfgYe+8liq7RQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Files_VehicleId1",
                table: "Files",
                column: "VehicleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Vehicles_VehicleId1",
                table: "Files",
                column: "VehicleId1",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
