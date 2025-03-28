using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0266210b-1b36-4087-9bb5-b9156000b49c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f88cc82-ff0b-4ffc-8156-b97126bd1b3f");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bookings");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a2ee0a02-3a54-4369-9bf9-7813aa7eb0dd", null, "Admin", "ADMIN" },
                    { "b60acca3-a568-4406-a90e-658c73d00a24", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2ee0a02-3a54-4369-9bf9-7813aa7eb0dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b60acca3-a568-4406-a90e-658c73d00a24");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0266210b-1b36-4087-9bb5-b9156000b49c", null, "User", "USER" },
                    { "0f88cc82-ff0b-4ffc-8156-b97126bd1b3f", null, "Admin", "ADMIN" }
                });
        }
    }
}
