using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_Intro_to_ef.Migrations
{
    /// <inheritdoc />
    public partial class add_count_listening : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountListening",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountListening",
                table: "Tracks");
        }
    }
}
