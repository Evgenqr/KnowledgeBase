using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KnowledgeBase.Migrations
{
    /// <inheritdoc />
    public partial class editmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Documents_DocumentId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_DocumentId",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "DocumentId1",
                table: "Files",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Documents",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "DocumentsId",
                table: "DocumentLaw",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Files_DocumentId1",
                table: "Files",
                column: "DocumentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Documents_DocumentId1",
                table: "Files",
                column: "DocumentId1",
                principalTable: "Documents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Documents_DocumentId1",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_DocumentId1",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "DocumentId1",
                table: "Files");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Documents",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "DocumentsId",
                table: "DocumentLaw",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Files_DocumentId",
                table: "Files",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Documents_DocumentId",
                table: "Files",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
