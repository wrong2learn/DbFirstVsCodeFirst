using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbFirstVsCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ARTIST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRST_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LAST_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BIRTH_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTIST", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GENRE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GENRE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BAND",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_GENRE = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAND", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BAND_GENRE_ID_GENRE",
                        column: x => x.ID_GENRE,
                        principalTable: "GENRE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALBUM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_BAND = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALBUM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ALBUM_BAND_ID_BAND",
                        column: x => x.ID_BAND,
                        principalTable: "BAND",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ARTISTSBAND",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ARTIST = table.Column<int>(type: "int", nullable: false),
                    ID_BAND = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ARTISTSBAND", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ARTISTSBAND_ARTIST_ID_ARTIST",
                        column: x => x.ID_ARTIST,
                        principalTable: "ARTIST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ARTISTSBAND_BAND_ID_BAND",
                        column: x => x.ID_BAND,
                        principalTable: "BAND",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SONG",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ALBUM = table.Column<int>(type: "int", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SONG", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SONG_ALBUM_ID_ALBUM",
                        column: x => x.ID_ALBUM,
                        principalTable: "ALBUM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALBUM_ID_BAND",
                table: "ALBUM",
                column: "ID_BAND");

            migrationBuilder.CreateIndex(
                name: "IX_ARTISTSBAND_ID_ARTIST",
                table: "ARTISTSBAND",
                column: "ID_ARTIST");

            migrationBuilder.CreateIndex(
                name: "IX_ARTISTSBAND_ID_BAND",
                table: "ARTISTSBAND",
                column: "ID_BAND");

            migrationBuilder.CreateIndex(
                name: "IX_BAND_ID_GENRE",
                table: "BAND",
                column: "ID_GENRE");

            migrationBuilder.CreateIndex(
                name: "IX_SONG_ID_ALBUM",
                table: "SONG",
                column: "ID_ALBUM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ARTISTSBAND");

            migrationBuilder.DropTable(
                name: "SONG");

            migrationBuilder.DropTable(
                name: "ARTIST");

            migrationBuilder.DropTable(
                name: "ALBUM");

            migrationBuilder.DropTable(
                name: "BAND");

            migrationBuilder.DropTable(
                name: "GENRE");
        }
    }
}
