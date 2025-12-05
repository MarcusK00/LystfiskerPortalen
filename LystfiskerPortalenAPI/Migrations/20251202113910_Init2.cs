using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LystfiskerPortalenAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPosts_AspNetUsers_ApplicationUserId",
                table: "UserPosts");

            migrationBuilder.DropIndex(
                name: "IX_UserPosts_ApplicationUserId",
                table: "UserPosts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserPosts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserPosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_UserPosts_ApplicationUserId",
                table: "UserPosts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPosts_AspNetUsers_ApplicationUserId",
                table: "UserPosts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
