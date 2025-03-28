using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ca6efb2-02a9-4408-8434-fdfca262f863");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d78f18cd-fa7d-427b-9140-9cc86f0ad2c1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "170a0699-937c-44a3-a0b3-4642ca85ae9c", null, "Admin", "ADMIN" },
                    { "26870942-a574-4f06-b99d-832517a2e289", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "170a0699-937c-44a3-a0b3-4642ca85ae9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26870942-a574-4f06-b99d-832517a2e289");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9ca6efb2-02a9-4408-8434-fdfca262f863", null, "User", "USER" },
                    { "d78f18cd-fa7d-427b-9140-9cc86f0ad2c1", null, "Admin", "ADMIN" }
                });
        }
    }
}
