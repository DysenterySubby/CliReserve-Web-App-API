using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "567d3156-1098-419d-80bd-42db7777d894");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1dd7e7e-49f2-4cc0-bcab-8f1d1b426219");

            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e65c85e-3d22-4de1-92b5-b7e31044dc4e", null, "User", "USER" },
                    { "9191abc4-155e-4df1-943d-3101c17696d3", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e65c85e-3d22-4de1-92b5-b7e31044dc4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9191abc4-155e-4df1-943d-3101c17696d3");

            migrationBuilder.DropColumn(
                name: "Finished",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "567d3156-1098-419d-80bd-42db7777d894", null, "User", "USER" },
                    { "e1dd7e7e-49f2-4cc0-bcab-8f1d1b426219", null, "Admin", "ADMIN" }
                });
        }
    }
}
