using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class gg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publishers_publisher_Id",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "publisher_Id",
                table: "Book",
                newName: "Publisher_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Book_publisher_Id",
                table: "Book",
                newName: "IX_Book_Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publishers_Publisher_Id",
                table: "Book",
                column: "Publisher_Id",
                principalTable: "Publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publishers_Publisher_Id",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "Publisher_Id",
                table: "Book",
                newName: "publisher_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Book_Publisher_Id",
                table: "Book",
                newName: "IX_Book_publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publishers_publisher_Id",
                table: "Book",
                column: "publisher_Id",
                principalTable: "Publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
