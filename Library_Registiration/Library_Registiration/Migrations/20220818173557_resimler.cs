using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Registiration.Migrations
{
    public partial class resimler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Publisher_resim_yol",
                table: "publishers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Book_resim_yol",
                table: "books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Author_resim_yol",
                table: "authors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publisher_resim_yol",
                table: "publishers");

            migrationBuilder.DropColumn(
                name: "Book_resim_yol",
                table: "books");

            migrationBuilder.DropColumn(
                name: "Author_resim_yol",
                table: "authors");
        }
    }
}
