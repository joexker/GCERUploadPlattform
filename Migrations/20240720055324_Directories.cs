using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Directories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VideoDirectoryId",
                table: "Video",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Directories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Video_VideoDirectoryId",
                table: "Video",
                column: "VideoDirectoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Directories_VideoDirectoryId",
                table: "Video",
                column: "VideoDirectoryId",
                principalTable: "Directories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Directories_VideoDirectoryId",
                table: "Video");

            migrationBuilder.DropTable(
                name: "Directories");

            migrationBuilder.DropIndex(
                name: "IX_Video_VideoDirectoryId",
                table: "Video");

            migrationBuilder.DropColumn(
                name: "VideoDirectoryId",
                table: "Video");
        }
    }
}
