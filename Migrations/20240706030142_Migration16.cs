using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliReserve.Migrations
{
    /// <inheritdoc />
    public partial class Migration16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatTypes_Clirs_ClirId",
                table: "SeatTypes");

            migrationBuilder.DropIndex(
                name: "IX_SeatTypes_ClirId",
                table: "SeatTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clirs",
                table: "Clirs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2ee0a02-3a54-4369-9bf9-7813aa7eb0dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b60acca3-a568-4406-a90e-658c73d00a24");

            migrationBuilder.DropColumn(
                name: "ClirId",
                table: "SeatTypes");

            migrationBuilder.DropColumn(
                name: "ClirId",
                table: "Clirs");

            migrationBuilder.AddColumn<string>(
                name: "ClirName",
                table: "SeatTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClirName",
                table: "Clirs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clirs",
                table: "Clirs",
                column: "ClirName");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatTypes_Clirs_ClirName",
                table: "SeatTypes");

            migrationBuilder.DropIndex(
                name: "IX_SeatTypes_ClirName",
                table: "SeatTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clirs",
                table: "Clirs");

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

            migrationBuilder.AddColumn<int>(
                name: "ClirId",
                table: "SeatTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ClirName",
                table: "Clirs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ClirId",
                table: "Clirs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clirs",
                table: "Clirs",
                column: "ClirId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a2ee0a02-3a54-4369-9bf9-7813aa7eb0dd", null, "Admin", "ADMIN" },
                    { "b60acca3-a568-4406-a90e-658c73d00a24", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatTypes_ClirId",
                table: "SeatTypes",
                column: "ClirId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatTypes_Clirs_ClirId",
                table: "SeatTypes",
                column: "ClirId",
                principalTable: "Clirs",
                principalColumn: "ClirId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
