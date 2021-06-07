using Microsoft.EntityFrameworkCore.Migrations;

namespace SnackisApp.Migrations
{
    public partial class PMIdKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrivateMessageId",
                table: "PrivateMessage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrivateMessageId",
                table: "PrivateMessage");
        }
    }
}
