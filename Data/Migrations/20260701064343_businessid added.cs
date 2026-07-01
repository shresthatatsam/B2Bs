using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace B2B.Migrations
{
    /// <inheritdoc />
    public partial class businessidadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("19bbe3d6-ebf9-4943-bd59-017fa8f67203"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6ad27234-ab03-46c7-b0d0-c00f39f1ea94"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8419caf8-c081-4d33-8016-6da8bedbef6d"));

            migrationBuilder.AddColumn<Guid>(
                name: "BusinessId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("7a8c63eb-eebd-48ff-90fc-921fb12dc1a2"), "System Admin", "Admin" },
                    { new Guid("8e3e120f-600d-4605-9364-ec489593ffac"), "Normal customer", "Buyer" },
                    { new Guid("cd3dfaf1-caaf-4851-a924-548f09f405cb"), "Business/Seller user", "Seller" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BusinessId",
                table: "Categories",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Businesses_BusinessId",
                table: "Categories",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Businesses_BusinessId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_BusinessId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7a8c63eb-eebd-48ff-90fc-921fb12dc1a2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8e3e120f-600d-4605-9364-ec489593ffac"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cd3dfaf1-caaf-4851-a924-548f09f405cb"));

            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("19bbe3d6-ebf9-4943-bd59-017fa8f67203"), "Normal customer", "Buyer" },
                    { new Guid("6ad27234-ab03-46c7-b0d0-c00f39f1ea94"), "System Admin", "Admin" },
                    { new Guid("8419caf8-c081-4d33-8016-6da8bedbef6d"), "Business/Seller user", "Seller" }
                });
        }
    }
}
