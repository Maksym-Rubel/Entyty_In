using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _06_EF_CodeFitrs.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prone = table.Column<string>(type: "char(50)", unicode: false, fixedLength: true, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaunchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Workers_Position_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Position",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectWorker",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    WorkersNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectWorker", x => new { x.ProjectsId, x.WorkersNumber });
                    table.ForeignKey(
                        name: "FK_ProjectWorker_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectWorker_Workers_WorkersNumber",
                        column: x => x.WorkersNumber,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ukraine" },
                    { 2, "USA" },
                    { 3, "Poland" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "Id", "Name", "Prone" },
                values: new object[,]
                {
                    { 1, "Management", "45-45-23412" },
                    { 2, "Programing", "45-45-23412" },
                    { 3, "Design", "45-45-23412" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "LaunchDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1982, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tetris" },
                    { 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CS" },
                    { 3, new DateTime(1999, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "PacMan" }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "Birthdate", "CountryId", "DepartmentId", "FirstName", "Salary", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, "Emma", 2700.0, "Miller" },
                    { 2, new DateTime(2005, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "Taras", 5800.0, "Bondar" },
                    { 3, new DateTime(2012, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Tomm", 3200.0, "Doe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorker_WorkersNumber",
                table: "ProjectWorker",
                column: "WorkersNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_CountryId",
                table: "Workers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_DepartmentId",
                table: "Workers",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectWorker");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
