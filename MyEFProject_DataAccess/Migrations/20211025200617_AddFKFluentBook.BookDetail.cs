using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEFProject_DataAccess.Migrations
{
    public partial class AddFKFluentBookBookDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fluent_Book_Id",
                table: "FluentBookDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_BookDetail_Id",
                table: "FluentBooks",
                column: "BookDetail_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookDetails_Fluent_Book_Id",
                table: "FluentBookDetails",
                column: "Fluent_Book_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookDetails_FluentBooks_Fluent_Book_Id",
                table: "FluentBookDetails",
                column: "Fluent_Book_Id",
                principalTable: "FluentBooks",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_BookDetail_Id",
                table: "FluentBooks",
                column: "BookDetail_Id",
                principalTable: "FluentBookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookDetails_FluentBooks_Fluent_BookBook_Id",
                table: "FluentBookDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentBookDetails_BookDetail_Id",
                table: "FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_BookDetail_Id",
                table: "FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_FluentBookDetails_Fluent_BookBook_Id",
                table: "FluentBookDetails");

            migrationBuilder.DropColumn(
                name: "Fluent_BookBook_Id",
                table: "FluentBookDetails");
        }
    }
}
