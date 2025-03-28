using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "053cdc43-cc80-475c-b4fe-9d04d644354a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "274718b8-bc3f-43d7-b25a-d518d0da3fa9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b3390eb-73c7-477d-8db5-7c29b34ea5dc", null, "Admin", "ADMIN" },
                    { "ea52a8fc-7679-48c0-8c06-9620acae6910", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b3390eb-73c7-477d-8db5-7c29b34ea5dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea52a8fc-7679-48c0-8c06-9620acae6910");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "053cdc43-cc80-475c-b4fe-9d04d644354a", null, "User", "USER" },
                    { "274718b8-bc3f-43d7-b25a-d518d0da3fa9", null, "Admin", "ADMIN" }
                });
        }
    }
}
