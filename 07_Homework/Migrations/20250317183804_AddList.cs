using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _07_Homework.Migrations
{
    /// <inheritdoc />
    public partial class AddList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Listening",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Listening",
                table: "Songs");
        }
    }
}
