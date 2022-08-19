using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Registiration.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    Admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.Admin_id);
                });

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Author_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author_age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author_about = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Author_id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Book_author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Book_publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Book_subject = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Book_id);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    Publisher_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Publisher_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher_About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher_Mail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.Publisher_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "publishers");
        }
    }
}
