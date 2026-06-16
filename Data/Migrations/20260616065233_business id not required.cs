using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace B2B.Migrations
{
    /// <inheritdoc />
    public partial class businessidnotrequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
