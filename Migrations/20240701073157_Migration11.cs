using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b3390eb-73c7-477d-8db5-7c29b34ea5dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea52a8fc-7679-48c0-8c06-9620acae6910");

            migrationBuilder.AddColumn<string>(
                name: "BookingId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Bookings_BookingId",
                table: "AspNetUsers",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Bookings_BookingId",
                table: "AspNetUsers");

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

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b3390eb-73c7-477d-8db5-7c29b34ea5dc", null, "Admin", "ADMIN" },
                    { "ea52a8fc-7679-48c0-8c06-9620acae6910", null, "User", "USER" }
                });
        }
    }
}
