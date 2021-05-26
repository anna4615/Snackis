using Microsoft.EntityFrameworkCore.Migrations;

namespace PostsAPI.Migrations
{
    public partial class postList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Post_PostId",
                table: "Post",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Post_PostId",
                table: "Post",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Post_PostId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_PostId",
                table: "Post");
        }
    }
}
