using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ClirName1",
                table: "SeatTypes");

            migrationBuilder.AlterColumn<string>(
                name: "ClirName",
                table: "SeatTypes",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1382761c-a988-4c87-ac7b-4d5ebd237271", null, "User", "USER" },
                    { "5291d7ea-b4d1-47ce-b80f-bd49b19ad763", null, "Admin", "ADMIN" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatTypes_Clirs_ClirName",
                table: "SeatTypes");

            migrationBuilder.DropIndex(
                name: "IX_SeatTypes_ClirName",
                table: "SeatTypes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1382761c-a988-4c87-ac7b-4d5ebd237271");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5291d7ea-b4d1-47ce-b80f-bd49b19ad763");

            migrationBuilder.AlterColumn<string>(
                name: "ClirName",
                table: "SeatTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
    }
}
