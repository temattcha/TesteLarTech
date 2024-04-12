using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    author = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<string>(type: "TEXT", nullable: false),
                    src = table.Column<string>(type: "TEXT", nullable: false),
                    peso = table.Column<string>(type: "TEXT", nullable: false),
                    idade = table.Column<string>(type: "TEXT", nullable: false),
                    acessos = table.Column<string>(type: "TEXT", nullable: false),
                    total_comments = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    CPF = table.Column<string>(type: "TEXT", nullable: true),
                    Birthday = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneType = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "id", "acessos", "author", "date", "idade", "peso", "src", "title", "total_comments" },
                values: new object[,]
                {
                    { 1, "209293", "Ashley", "2024-03-20 21:16:20", "2", "5", "https://i.pinimg.com/564x/e7/54/cc/e754cc4c1e43e85ae059d640ac3a4d81.jpg", "Fifi", "2" },
                    { 2, "123345", "Mat", "2024-04-10 21:16:20", "6", "6", "https://i.pinimg.com/564x/6c/93/e6/6c93e605661e7d105bd6ad473ccfaa45.jpg", "Mingau", "1" },
                    { 3, "13215", "João", "2024-02-02 21:16:20", "3", "3", "https://i.pinimg.com/564x/01/e6/09/01e6097603ceb0a1c3b16af1a8f56f39.jpg", "Bolinho", "1" },
                    { 4, "56746", "Ana", "2024-01-12 21:16:20", "8", "2", "https://i.pinimg.com/564x/01/88/b4/0188b44239015be9f8efe7e81aa3d40a.jpg", "Nico", "0" },
                    { 5, "76", "Ricardo", "2024-03-21 21:16:20", "1", "4", "https://i.pinimg.com/564x/ef/10/c2/ef10c2acca595eae0b0f67430580c3a1.jpg", "Maggie", "0" },
                    { 6, "365753", "Mat", "2024-04-14 21:16:20", "9", "4", "https://i.pinimg.com/564x/92/73/c6/9273c692dd46fbb5b3d9b5018e09ee61.jpg", "Tom", "0" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "CPF", "IsActive", "Name", "Password", "Username" },
                values: new object[] { new Guid("38987d73-054f-4236-937c-3c105a09a9f9"), "01/01/1900", "123.123.123-45", true, "Mat", "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_UserId",
                table: "Phones",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
