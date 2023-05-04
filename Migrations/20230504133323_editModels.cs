using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowledgeBase.Migrations
{
    /// <inheritdoc />
    public partial class editModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "User",
                newName: "Username");

            migrationBuilder.AddColumn<bool>(
                name: "RememberMe",
                table: "User",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RememberMe",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "User",
                newName: "NickName");
        }
    }
}
