using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibrary.Data.Migrations
{
    public partial class EnableMultibleRentalsForBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowersBooks",
                table: "BorrowersBooks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BorrowersBooks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowersBooks",
                table: "BorrowersBooks",
                columns: new[] { "Id", "BookId", "BorrowerId" });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowersBooks_BookId",
                table: "BorrowersBooks",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowersBooks",
                table: "BorrowersBooks");

            migrationBuilder.DropIndex(
                name: "IX_BorrowersBooks_BookId",
                table: "BorrowersBooks");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BorrowersBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowersBooks",
                table: "BorrowersBooks",
                columns: new[] { "BookId", "BorrowerId" });
        }
    }
}
