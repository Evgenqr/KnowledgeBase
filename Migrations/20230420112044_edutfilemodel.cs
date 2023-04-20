using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowledgeBase.Migrations
{
    /// <inheritdoc />
    public partial class edutfilemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RealTitle",
                table: "Files",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealTitle",
                table: "Files");
        }
    }
}
