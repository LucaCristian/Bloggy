using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "246ab847-f77f-4822-a065-fca2bc61d3c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8791a3a3-e023-4868-8c75-9b6c358f86e6");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Pages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ecd3f44-8b26-4c56-a605-967c7218353c", null, "User", "USER" },
                    { "e4a75849-7e2a-49be-8960-9a2ad9ffc8a8", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ecd3f44-8b26-4c56-a605-967c7218353c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4a75849-7e2a-49be-8960-9a2ad9ffc8a8");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "246ab847-f77f-4822-a065-fca2bc61d3c2", null, "Admin", "ADMIN" },
                    { "8791a3a3-e023-4868-8c75-9b6c358f86e6", null, "User", "USER" }
                });
        }
    }
}
