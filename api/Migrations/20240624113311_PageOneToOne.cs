using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class PageOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3991adda-5ae1-4e6f-a734-b13aee4f46c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6193f54a-2847-4e2d-8d31-b2d54da605b8");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Pages",
                type: "nvarchar(450)",
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

            migrationBuilder.CreateIndex(
                name: "IX_Pages_AppUserId",
                table: "Pages",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_AspNetUsers_AppUserId",
                table: "Pages",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_AspNetUsers_AppUserId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_AppUserId",
                table: "Pages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "246ab847-f77f-4822-a065-fca2bc61d3c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8791a3a3-e023-4868-8c75-9b6c358f86e6");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Pages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3991adda-5ae1-4e6f-a734-b13aee4f46c3", null, "User", "USER" },
                    { "6193f54a-2847-4e2d-8d31-b2d54da605b8", null, "Admin", "ADMIN" }
                });
        }
    }
}
