using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_BookingId",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "170a0699-937c-44a3-a0b3-4642ca85ae9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26870942-a574-4f06-b99d-832517a2e289");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "053cdc43-cc80-475c-b4fe-9d04d644354a", null, "User", "USER" },
                    { "274718b8-bc3f-43d7-b25a-d518d0da3fa9", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "053cdc43-cc80-475c-b4fe-9d04d644354a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "274718b8-bc3f-43d7-b25a-d518d0da3fa9");

            migrationBuilder.AddColumn<string>(
                name: "BookingId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "170a0699-937c-44a3-a0b3-4642ca85ae9c", null, "Admin", "ADMIN" },
                    { "26870942-a574-4f06-b99d-832517a2e289", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_BookingId",
                table: "Bookings",
                column: "BookingId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
