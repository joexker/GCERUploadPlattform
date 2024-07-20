using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Implirgendwasidk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirId",
                table: "Video",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Directories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Directories_TeamId",
                table: "Directories",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directories_Team_TeamId",
                table: "Directories",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directories_Team_TeamId",
                table: "Directories");

            migrationBuilder.DropIndex(
                name: "IX_Directories_TeamId",
                table: "Directories");

            migrationBuilder.DropColumn(
                name: "DirId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Directories");
        }
    }
}
