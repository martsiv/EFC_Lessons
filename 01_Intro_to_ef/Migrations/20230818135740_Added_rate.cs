using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_Intro_to_ef.Migrations
{
    /// <inheritdoc />
    public partial class Added_rate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RateOfAlbum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateOfAlbum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateOfAlbum_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RateOfTrack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateOfTrack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateOfTrack_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RateOfAlbum_AlbumId",
                table: "RateOfAlbum",
                column: "AlbumId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RateOfTrack_TrackId",
                table: "RateOfTrack",
                column: "TrackId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RateOfAlbum");

            migrationBuilder.DropTable(
                name: "RateOfTrack");
        }
    }
}
