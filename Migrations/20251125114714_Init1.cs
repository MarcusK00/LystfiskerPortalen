using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LystfiskerPortalen.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catches_Fishes_FishSpecies",
                table: "Catches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fishes",
                table: "Fishes");

            migrationBuilder.DropIndex(
                name: "IX_Catches_FishSpecies",
                table: "Catches");

            migrationBuilder.DeleteData(
                table: "Fishes",
                keyColumn: "Species",
                keyValue: "Pike");

            migrationBuilder.DeleteData(
                table: "Fishes",
                keyColumn: "Species",
                keyValue: "Salmon");

            migrationBuilder.DeleteData(
                table: "Fishes",
                keyColumn: "Species",
                keyValue: "Trout");

            migrationBuilder.DropColumn(
                name: "FishSpecies",
                table: "Catches");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Fishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Species",
                table: "Fishes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fishes",
                table: "Fishes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Fishes",
                columns: new[] { "Id", "Species" },
                values: new object[,]
                {
                    { 1, "Trout" },
                    { 2, "Salmon" },
                    { 3, "Pike" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catches_FishId",
                table: "Catches",
                column: "FishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catches_Fishes_FishId",
                table: "Catches",
                column: "FishId",
                principalTable: "Fishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catches_Fishes_FishId",
                table: "Catches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fishes",
                table: "Fishes");

            migrationBuilder.DropIndex(
                name: "IX_Catches_FishId",
                table: "Catches");

            migrationBuilder.DeleteData(
                table: "Fishes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fishes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fishes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Species",
                table: "Fishes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Fishes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "FishSpecies",
                table: "Catches",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fishes",
                table: "Fishes",
                column: "Species");

            migrationBuilder.InsertData(
                table: "Fishes",
                columns: new[] { "Species", "Id" },
                values: new object[,]
                {
                    { "Pike", 0 },
                    { "Salmon", 0 },
                    { "Trout", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catches_FishSpecies",
                table: "Catches",
                column: "FishSpecies");

            migrationBuilder.AddForeignKey(
                name: "FK_Catches_Fishes_FishSpecies",
                table: "Catches",
                column: "FishSpecies",
                principalTable: "Fishes",
                principalColumn: "Species",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
