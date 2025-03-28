using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropIndex(
                name: "IX_SeatTypes_ClirName",
                table: "SeatTypes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b712bc63-8323-430f-ae35-68e12b12cebb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6171172-64a0-49ea-9f8f-3fa850fbdb2f");

            migrationBuilder.DropColumn(
                name: "ClirName",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b712bc63-8323-430f-ae35-68e12b12cebb", null, "User", "USER" },
                    { "e6171172-64a0-49ea-9f8f-3fa850fbdb2f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatTypes_ClirName",
                table: "SeatTypes",
                column: "ClirName");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatTypes_Clirs_ClirName",
                table: "SeatTypes",
                column: "ClirName",
                principalTable: "Clirs",
                principalColumn: "ClirName");
        }
    }
}
