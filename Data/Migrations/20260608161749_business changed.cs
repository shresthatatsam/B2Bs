using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace B2B.Migrations
{
    /// <inheritdoc />
    public partial class businesschanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3122c174-26b1-4430-a6ef-2e5c86ca6e75"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a9ae5f58-5ee6-4a0b-b938-452342996242"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e3c784c5-3487-462e-9b57-4e5059ce9288"));

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Businesses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Businesses",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("37e37078-6fcc-4156-9504-732d745af181"), "Normal customer", "Buyer" },
                    { new Guid("630fbd9c-0908-4c80-9cac-49a251b66eea"), "Business/Seller user", "Seller" },
                    { new Guid("9415aac0-d56a-4570-9ccb-994e98012707"), "System Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("37e37078-6fcc-4156-9504-732d745af181"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("630fbd9c-0908-4c80-9cac-49a251b66eea"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9415aac0-d56a-4570-9ccb-994e98012707"));

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Businesses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Businesses",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3122c174-26b1-4430-a6ef-2e5c86ca6e75"), "Normal customer", "Buyer" },
                    { new Guid("a9ae5f58-5ee6-4a0b-b938-452342996242"), "Business/Seller user", "Seller" },
                    { new Guid("e3c784c5-3487-462e-9b57-4e5059ce9288"), "System Admin", "Admin" }
                });
        }
    }
}
