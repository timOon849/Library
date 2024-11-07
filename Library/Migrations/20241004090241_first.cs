using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    Id_Reader = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.Id_Reader);
                });

            migrationBuilder.CreateTable(
                name: "Zhanrs",
                columns: table => new
                {
                    ID_Zhanr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Zhanr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zhanrs", x => x.ID_Zhanr);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    ID_Book = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfIzd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Zhanr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.ID_Book);
                    table.ForeignKey(
                        name: "FK_Book_Zhanrs_ID_Zhanr",
                        column: x => x.ID_Zhanr,
                        principalTable: "Zhanrs",
                        principalColumn: "ID_Zhanr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentHistory",
                columns: table => new
                {
                    ID_History = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Srok = table.Column<int>(type: "int", nullable: false),
                    ID_Book = table.Column<int>(type: "int", nullable: false),
                    ID_Reader = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentHistory", x => x.ID_History);
                    table.ForeignKey(
                        name: "FK_RentHistory_Book_ID_Book",
                        column: x => x.ID_Book,
                        principalTable: "Book",
                        principalColumn: "ID_Book",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentHistory_Readers_ID_Reader",
                        column: x => x.ID_Reader,
                        principalTable: "Readers",
                        principalColumn: "Id_Reader",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_ID_Zhanr",
                table: "Book",
                column: "ID_Zhanr");

            migrationBuilder.CreateIndex(
                name: "IX_RentHistory_ID_Book",
                table: "RentHistory",
                column: "ID_Book");

            migrationBuilder.CreateIndex(
                name: "IX_RentHistory_ID_Reader",
                table: "RentHistory",
                column: "ID_Reader");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentHistory");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "Zhanrs");
        }
    }
}
