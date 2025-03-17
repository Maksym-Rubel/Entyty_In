using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _06_EF_CodeFitrs.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Countries_CountryId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Position_DepartmentId",
                table: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Workers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Countries_CountryId",
                table: "Workers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Position_DepartmentId",
                table: "Workers",
                column: "DepartmentId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Countries_CountryId",
                table: "Workers");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Position_DepartmentId",
                table: "Workers");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Workers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Workers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Countries_CountryId",
                table: "Workers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Position_DepartmentId",
                table: "Workers",
                column: "DepartmentId",
                principalTable: "Position",
                principalColumn: "Id");
        }
    }
}
