using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
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
                keyValue: "642ff574-d3d1-4413-9919-e679616dad1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd349d4c-d13d-4654-b3cf-db1bf0bd8645");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16c457ba-8479-437a-8f9d-9eef2571549a", null, "User", "USER" },
                    { "e1585823-f6a4-4c00-b15c-fb742634f884", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16c457ba-8479-437a-8f9d-9eef2571549a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1585823-f6a4-4c00-b15c-fb742634f884");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "642ff574-d3d1-4413-9919-e679616dad1f", null, "Admin", "ADMIN" },
                    { "cd349d4c-d13d-4654-b3cf-db1bf0bd8645", null, "User", "USER" }
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
