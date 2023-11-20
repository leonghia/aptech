using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNetMvc.Migrations
{
    /// <inheritdoc />
    public partial class SeedingProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "Rating",
                table: "Products",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<decimal>(
                name: "Revenue",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Sales",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SalesPerDay",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SalesPerMonth",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "LastUpdate", "Name", "Price", "Rating", "Revenue", "Sales", "SalesPerDay", "SalesPerMonth", "Stock" },
                values: new object[,]
                {
                    { 1, 1, null, "https://flowbite.s3.amazonaws.com/blocks/application-ui/products/imac-front-image.png", new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7878), "Apple iMac 27\"\"", 799.88m, 5f, 3200000m, 1600000, 1.47, 0.46999999999999997, 95 },
                    { 2, 1, null, "https://flowbite.s3.amazonaws.com/blocks/application-ui/products/imac-front-image.png", new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7908), "Apple iMac 20\"\"", 799.88m, 5f, 785000m, 6000000, 1.1499999999999999, 0.32000000000000001, 108 },
                    { 3, 2, null, "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/apple-iphone-14.png", new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7913), "Apple iPhone 14", 593.00m, 4f, 3200000m, 1200000, 1.0, 0.94999999999999996, 24 },
                    { 4, 3, null, "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/apple-ipad-air.png", new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7919), "Apple iPad Air", 559.00m, 4f, 425000m, 298000, 0.46999999999999997, 1.0, 287 },
                    { 5, 4, null, "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/xbox-series-s.png", new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7926), "Xbox Series S", 274.99m, 5f, 345000m, 99, 1.6100000000000001, 0.29999999999999999, 450 },
                    { 6, 4, null, "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/playstation-5.png", new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7934), "PlayStation 5", 479.00m, 4f, 4200000m, 2100000, 1.4099999999999999, 0.11, 2345 },
                    { 7, 4, null, "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/xbox-series-x.png", new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7938), "Xbox Series X", 489.99m, 5f, 2270000m, 989000, 7.0899999999999999, 3.3199999999999998, 235 },
                    { 8, 5, null, "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/apple-watch-se.png", new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7945), "Apple Watch SE", 201.48m, 5f, 45000m, 102, 4.96, 0.73999999999999999, 433 },
                    { 9, 6, null, "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/nikon-d850.png", new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7956), "NIKON D850", 2496.95m, 3f, 1520000m, 1200000, 0.20000000000000001, 0.73999999999999999, 351 },
                    { 10, 7, null, "https://flowbite.s3.amazonaws.com/blocks/application-ui/devices/benq-ex2710q.png", new DateTime(2023, 11, 15, 3, 36, 2, 953, DateTimeKind.Utc).AddTicks(7960), "Monitor BENQ EX2710Q", 349.99m, 4f, 1200000m, 211000, 4.1200000000000001, 0.29999999999999999, 1242 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Revenue",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Sales",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalesPerDay",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SalesPerMonth",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Products");
        }
    }
}
