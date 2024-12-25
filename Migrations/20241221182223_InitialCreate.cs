using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIDemoStudent.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Photopath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "Photopath" },
                values: new object[,]
                {
                    { 1, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "leemisa@gmail.com", "Leemisa", 0, "Moleko", "Images/leemisa.png" },
                    { 2, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "john@gmail.com", "John", 0, "Doe", "images/john.png" },
                    { 3, new DateTime(2004, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "jane@gmail.com", "Jane", 1, "Doe", "images/john.png" },
                    { 4, new DateTime(2005, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "jons@gmail.com", "Natalie", 1, "Jons", "images/john.png" },
                    { 5, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mike@gmail.com", "Mike", 2, "Rose", "images/john.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
