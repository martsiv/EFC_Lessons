using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_Intro_to_ef.Migrations
{
    /// <inheritdoc />
    public partial class add_text : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Tracks");
        }
    }
}
