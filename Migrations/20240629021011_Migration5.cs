using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Seats_SeatId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_SeatTypes_SeatTypeId",
                table: "Seats");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "790852e9-09b6-4bf9-a2fb-f4dc304730eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4710da3-8e44-435b-b4ea-bab88261eef2");

            migrationBuilder.AlterColumn<string>(
                name: "SeatTypeId",
                table: "Seats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SeatId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b4e9ff2-267b-4c37-b4b0-758fa4f8281a", null, "Admin", "ADMIN" },
                    { "aaed8878-df62-41a5-a43c-b49f7dc65eb2", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Seats_SeatId",
                table: "Bookings",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "SeatId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_SeatTypes_SeatTypeId",
                table: "Seats",
                column: "SeatTypeId",
                principalTable: "SeatTypes",
                principalColumn: "SeatTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Seats_SeatId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_SeatTypes_SeatTypeId",
                table: "Seats");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b4e9ff2-267b-4c37-b4b0-758fa4f8281a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aaed8878-df62-41a5-a43c-b49f7dc65eb2");

            migrationBuilder.AlterColumn<string>(
                name: "SeatTypeId",
                table: "Seats",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "SeatId",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "790852e9-09b6-4bf9-a2fb-f4dc304730eb", null, "Admin", "ADMIN" },
                    { "e4710da3-8e44-435b-b4ea-bab88261eef2", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Seats_SeatId",
                table: "Bookings",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_SeatTypes_SeatTypeId",
                table: "Seats",
                column: "SeatTypeId",
                principalTable: "SeatTypes",
                principalColumn: "SeatTypeId");
        }
    }
}
