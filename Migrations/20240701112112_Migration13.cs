using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "833fc147-dbbd-437a-bcde-a12d40476174");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc951d6e-0222-4cf4-a342-35f4cb03e9a2");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00e08bad-d6c7-446a-8b0f-143bc49b091a", null, "User", "USER" },
                    { "f42d9249-89f7-436c-974d-9f69194acd0d", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00e08bad-d6c7-446a-8b0f-143bc49b091a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f42d9249-89f7-436c-974d-9f69194acd0d");

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
                    { "833fc147-dbbd-437a-bcde-a12d40476174", null, "User", "USER" },
                    { "bc951d6e-0222-4cf4-a342-35f4cb03e9a2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BookingId",
                table: "AspNetUsers",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Bookings_BookingId",
                table: "AspNetUsers",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId");
        }
    }
}
