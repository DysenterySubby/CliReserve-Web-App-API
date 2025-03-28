using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f31d8b6-7150-4155-9c52-653d09ab2185");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88569b05-d395-48e9-ac80-d2e29fd6d5bd");

            migrationBuilder.AddColumn<string>(
                name: "ClirName",
                table: "SeatTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClirName1",
                table: "SeatTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a2f6ec4-358e-46dd-af6c-b171476e9a0b", null, "Admin", "ADMIN" },
                    { "442a46c0-f717-458f-a5d8-daefe2050f02", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatTypes_ClirName1",
                table: "SeatTypes",
                column: "ClirName1");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatTypes_Clirs_ClirName1",
                table: "SeatTypes",
                column: "ClirName1",
                principalTable: "Clirs",
                principalColumn: "ClirName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatTypes_Clirs_ClirName1",
                table: "SeatTypes");

            migrationBuilder.DropIndex(
                name: "IX_SeatTypes_ClirName1",
                table: "SeatTypes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a2f6ec4-358e-46dd-af6c-b171476e9a0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "442a46c0-f717-458f-a5d8-daefe2050f02");

            migrationBuilder.DropColumn(
                name: "ClirName",
                table: "SeatTypes");

            migrationBuilder.DropColumn(
                name: "ClirName1",
                table: "SeatTypes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f31d8b6-7150-4155-9c52-653d09ab2185", null, "Admin", "ADMIN" },
                    { "88569b05-d395-48e9-ac80-d2e29fd6d5bd", null, "User", "USER" }
                });
        }
    }
}
