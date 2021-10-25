using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEFProject_DataAccess.Migrations
{
    public partial class AddFkBooksPublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_FluentBookDetails_FluentBooks_Fluent_BookBook_Id",
            //    table: "FluentBookDetails");

            //migrationBuilder.DropIndex(
            //    name: "IX_FluentBookDetails_Fluent_BookBook_Id",
            //    table: "FluentBookDetails");

            //migrationBuilder.DropColumn(
            //    name: "Fluent_BookBook_Id",
            //    table: "FluentBookDetails");

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_Publisher_Id",
                table: "FluentBooks",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentPublishers_Publisher_Id",
                table: "FluentBooks",
                column: "Publisher_Id",
                principalTable: "FluentPublishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentPublishers_Publisher_Id",
                table: "FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_Publisher_Id",
                table: "FluentBooks");

            migrationBuilder.AddColumn<int>(
                name: "Fluent_BookBook_Id",
                table: "FluentBookDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookDetails_Fluent_BookBook_Id",
                table: "FluentBookDetails",
                column: "Fluent_BookBook_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookDetails_FluentBooks_Fluent_BookBook_Id",
                table: "FluentBookDetails",
                column: "Fluent_BookBook_Id",
                principalTable: "FluentBooks",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
