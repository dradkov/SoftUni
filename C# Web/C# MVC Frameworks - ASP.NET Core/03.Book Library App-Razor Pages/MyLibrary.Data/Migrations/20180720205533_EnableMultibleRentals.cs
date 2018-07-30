using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibrary.Data.Migrations
{
    public partial class EnableMultibleRentals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowersBooks",
                table: "BorrowersBooks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BorrowersBooks",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowersBooks",
                table: "BorrowersBooks",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowersBooks",
                table: "BorrowersBooks");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BorrowersBooks",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowersBooks",
                table: "BorrowersBooks",
                columns: new[] { "Id", "BookId", "BorrowerId" });
        }
    }
}
