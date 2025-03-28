using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class _20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1382761c-a988-4c87-ac7b-4d5ebd237271");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5291d7ea-b4d1-47ce-b80f-bd49b19ad763");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "567d3156-1098-419d-80bd-42db7777d894", null, "User", "USER" },
                    { "e1dd7e7e-49f2-4cc0-bcab-8f1d1b426219", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "567d3156-1098-419d-80bd-42db7777d894");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1dd7e7e-49f2-4cc0-bcab-8f1d1b426219");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1382761c-a988-4c87-ac7b-4d5ebd237271", null, "User", "USER" },
                    { "5291d7ea-b4d1-47ce-b80f-bd49b19ad763", null, "Admin", "ADMIN" }
                });
        }
    }
}
