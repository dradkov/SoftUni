using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibrary.Data.Migrations
{
    public partial class AddDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistory_Books_BookId",
                table: "BorrowHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistory_Borrowers_BorrowerId",
                table: "BorrowHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowHistory",
                table: "BorrowHistory");

            migrationBuilder.RenameTable(
                name: "BorrowHistory",
                newName: "BorrowHistories");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowHistory_BorrowerId",
                table: "BorrowHistories",
                newName: "IX_BorrowHistories_BorrowerId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowHistory_BookId",
                table: "BorrowHistories",
                newName: "IX_BorrowHistories_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowHistories",
                table: "BorrowHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistories_Books_BookId",
                table: "BorrowHistories",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistories_Borrowers_BorrowerId",
                table: "BorrowHistories",
                column: "BorrowerId",
                principalTable: "Borrowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistories_Books_BookId",
                table: "BorrowHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowHistories_Borrowers_BorrowerId",
                table: "BorrowHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowHistories",
                table: "BorrowHistories");

            migrationBuilder.RenameTable(
                name: "BorrowHistories",
                newName: "BorrowHistory");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowHistories_BorrowerId",
                table: "BorrowHistory",
                newName: "IX_BorrowHistory_BorrowerId");

            migrationBuilder.RenameIndex(
                name: "IX_BorrowHistories_BookId",
                table: "BorrowHistory",
                newName: "IX_BorrowHistory_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowHistory",
                table: "BorrowHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistory_Books_BookId",
                table: "BorrowHistory",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowHistory_Borrowers_BorrowerId",
                table: "BorrowHistory",
                column: "BorrowerId",
                principalTable: "Borrowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
