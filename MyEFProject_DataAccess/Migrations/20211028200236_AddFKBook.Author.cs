using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEFProject_DataAccess.Migrations
{
    public partial class AddFKBookAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthors_Author_Id",
                table: "BookAuthors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.CreateTable(
                name: "FluentBookAuthors",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBookAuthors", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_FluentBookAuthors_FluentAuthors_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "FluentAuthors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentBookAuthors_FluentBooks_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "FluentBooks",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_Book_Id",
                table: "BookAuthors",
                column: "Book_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthors_Book_Id",
                table: "FluentBookAuthors",
                column: "Book_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentBookAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthors_Book_Id",
                table: "BookAuthors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors",
                columns: new[] { "Book_Id", "Author_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_Author_Id",
                table: "BookAuthors",
                column: "Author_Id");
        }
    }
}
