using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.EntityFactory.Migrations
{
    public partial class _20200604_sqlite_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BlogImages",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Image = table.Column<byte[]>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    IdBlog = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogImages", x => x.id);
                    table.ForeignKey(
                        name: "FK_BlogImages_Blogs_IdBlog",
                        column: x => x.IdBlog,
                        principalTable: "Blogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IdBlog = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Posts_Blogs_IdBlog",
                        column: x => x.IdBlog,
                        principalTable: "Blogs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogImages_IdBlog",
                table: "BlogImages",
                column: "IdBlog",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IdBlog",
                table: "Posts",
                column: "IdBlog");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogImages");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
