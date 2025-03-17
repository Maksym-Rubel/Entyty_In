using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _07_Homework.Migrations
{
    /// <inheritdoc />
    public partial class AddText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SongText",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SongText",
                table: "Songs");
        }
    }
}
