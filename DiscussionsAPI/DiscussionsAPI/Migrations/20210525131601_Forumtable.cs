using Microsoft.EntityFrameworkCore.Migrations;

namespace PostsAPI.Migrations
{
    public partial class Forumtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ForumId",
                table: "Subject",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subject_ForumId",
                table: "Subject",
                column: "ForumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Forum_ForumId",
                table: "Subject",
                column: "ForumId",
                principalTable: "Forum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Forum_ForumId",
                table: "Subject");

            migrationBuilder.DropTable(
                name: "Forum");

            migrationBuilder.DropIndex(
                name: "IX_Subject_ForumId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "ForumId",
                table: "Subject");
        }
    }
}
