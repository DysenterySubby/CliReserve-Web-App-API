using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BookingId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17d42268-f848-48ef-a822-6ca502449a75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f0a8bce-6c6e-4a2e-bfbc-54809c6bb729");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "833fc147-dbbd-437a-bcde-a12d40476174", null, "User", "USER" },
                    { "bc951d6e-0222-4cf4-a342-35f4cb03e9a2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BookingId",
                table: "AspNetUsers",
                column: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_BookingId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "833fc147-dbbd-437a-bcde-a12d40476174");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc951d6e-0222-4cf4-a342-35f4cb03e9a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17d42268-f848-48ef-a822-6ca502449a75", null, "Admin", "ADMIN" },
                    { "1f0a8bce-6c6e-4a2e-bfbc-54809c6bb729", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BookingId",
                table: "AspNetUsers",
                column: "BookingId",
                unique: true,
                filter: "[BookingId] IS NOT NULL");
        }
    }
}
