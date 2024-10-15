using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbFirstVsCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ALBUM_BAND_ID_BAND",
                table: "ALBUM");

            migrationBuilder.DropForeignKey(
                name: "FK_ARTISTSBAND_ARTIST_ID_ARTIST",
                table: "ARTISTSBAND");

            migrationBuilder.DropForeignKey(
                name: "FK_ARTISTSBAND_BAND_ID_BAND",
                table: "ARTISTSBAND");

            migrationBuilder.DropForeignKey(
                name: "FK_BAND_GENRE_ID_GENRE",
                table: "BAND");

            migrationBuilder.DropForeignKey(
                name: "FK_SONG_ALBUM_ID_ALBUM",
                table: "SONG");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SONG",
                table: "SONG");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GENRE",
                table: "GENRE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BAND",
                table: "BAND");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ARTISTSBAND",
                table: "ARTISTSBAND");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ARTIST",
                table: "ARTIST");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ALBUM",
                table: "ALBUM");

            migrationBuilder.RenameTable(
                name: "SONG",
                newName: "SONGS");

            migrationBuilder.RenameTable(
                name: "GENRE",
                newName: "GENRES");

            migrationBuilder.RenameTable(
                name: "BAND",
                newName: "BANDS");

            migrationBuilder.RenameTable(
                name: "ARTISTSBAND",
                newName: "ARTISTSBANDS");

            migrationBuilder.RenameTable(
                name: "ARTIST",
                newName: "ARTISTS");

            migrationBuilder.RenameTable(
                name: "ALBUM",
                newName: "ALBUMS");

            migrationBuilder.RenameIndex(
                name: "IX_SONG_ID_ALBUM",
                table: "SONGS",
                newName: "IX_SONGS_ID_ALBUM");

            migrationBuilder.RenameIndex(
                name: "IX_BAND_ID_GENRE",
                table: "BANDS",
                newName: "IX_BANDS_ID_GENRE");

            migrationBuilder.RenameIndex(
                name: "IX_ARTISTSBAND_ID_BAND",
                table: "ARTISTSBANDS",
                newName: "IX_ARTISTSBANDS_ID_BAND");

            migrationBuilder.RenameIndex(
                name: "IX_ARTISTSBAND_ID_ARTIST",
                table: "ARTISTSBANDS",
                newName: "IX_ARTISTSBANDS_ID_ARTIST");

            migrationBuilder.RenameIndex(
                name: "IX_ALBUM_ID_BAND",
                table: "ALBUMS",
                newName: "IX_ALBUMS_ID_BAND");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SONGS",
                table: "SONGS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GENRES",
                table: "GENRES",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BANDS",
                table: "BANDS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ARTISTSBANDS",
                table: "ARTISTSBANDS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ARTISTS",
                table: "ARTISTS",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ALBUMS",
                table: "ALBUMS",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ALBUMS_BANDS_ID_BAND",
                table: "ALBUMS",
                column: "ID_BAND",
                principalTable: "BANDS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ARTISTSBANDS_ARTISTS_ID_ARTIST",
                table: "ARTISTSBANDS",
                column: "ID_ARTIST",
                principalTable: "ARTISTS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ARTISTSBANDS_BANDS_ID_BAND",
                table: "ARTISTSBANDS",
                column: "ID_BAND",
                principalTable: "BANDS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BANDS_GENRES_ID_GENRE",
                table: "BANDS",
                column: "ID_GENRE",
                principalTable: "GENRES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SONGS_ALBUMS_ID_ALBUM",
                table: "SONGS",
                column: "ID_ALBUM",
                principalTable: "ALBUMS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ALBUMS_BANDS_ID_BAND",
                table: "ALBUMS");

            migrationBuilder.DropForeignKey(
                name: "FK_ARTISTSBANDS_ARTISTS_ID_ARTIST",
                table: "ARTISTSBANDS");

            migrationBuilder.DropForeignKey(
                name: "FK_ARTISTSBANDS_BANDS_ID_BAND",
                table: "ARTISTSBANDS");

            migrationBuilder.DropForeignKey(
                name: "FK_BANDS_GENRES_ID_GENRE",
                table: "BANDS");

            migrationBuilder.DropForeignKey(
                name: "FK_SONGS_ALBUMS_ID_ALBUM",
                table: "SONGS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SONGS",
                table: "SONGS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GENRES",
                table: "GENRES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BANDS",
                table: "BANDS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ARTISTSBANDS",
                table: "ARTISTSBANDS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ARTISTS",
                table: "ARTISTS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ALBUMS",
                table: "ALBUMS");

            migrationBuilder.RenameTable(
                name: "SONGS",
                newName: "SONG");

            migrationBuilder.RenameTable(
                name: "GENRES",
                newName: "GENRE");

            migrationBuilder.RenameTable(
                name: "BANDS",
                newName: "BAND");

            migrationBuilder.RenameTable(
                name: "ARTISTSBANDS",
                newName: "ARTISTSBAND");

            migrationBuilder.RenameTable(
                name: "ARTISTS",
                newName: "ARTIST");

            migrationBuilder.RenameTable(
                name: "ALBUMS",
                newName: "ALBUM");

            migrationBuilder.RenameIndex(
                name: "IX_SONGS_ID_ALBUM",
                table: "SONG",
                newName: "IX_SONG_ID_ALBUM");

            migrationBuilder.RenameIndex(
                name: "IX_BANDS_ID_GENRE",
                table: "BAND",
                newName: "IX_BAND_ID_GENRE");

            migrationBuilder.RenameIndex(
                name: "IX_ARTISTSBANDS_ID_BAND",
                table: "ARTISTSBAND",
                newName: "IX_ARTISTSBAND_ID_BAND");

            migrationBuilder.RenameIndex(
                name: "IX_ARTISTSBANDS_ID_ARTIST",
                table: "ARTISTSBAND",
                newName: "IX_ARTISTSBAND_ID_ARTIST");

            migrationBuilder.RenameIndex(
                name: "IX_ALBUMS_ID_BAND",
                table: "ALBUM",
                newName: "IX_ALBUM_ID_BAND");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SONG",
                table: "SONG",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GENRE",
                table: "GENRE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BAND",
                table: "BAND",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ARTISTSBAND",
                table: "ARTISTSBAND",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ARTIST",
                table: "ARTIST",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ALBUM",
                table: "ALBUM",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ALBUM_BAND_ID_BAND",
                table: "ALBUM",
                column: "ID_BAND",
                principalTable: "BAND",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ARTISTSBAND_ARTIST_ID_ARTIST",
                table: "ARTISTSBAND",
                column: "ID_ARTIST",
                principalTable: "ARTIST",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ARTISTSBAND_BAND_ID_BAND",
                table: "ARTISTSBAND",
                column: "ID_BAND",
                principalTable: "BAND",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BAND_GENRE_ID_GENRE",
                table: "BAND",
                column: "ID_GENRE",
                principalTable: "GENRE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SONG_ALBUM_ID_ALBUM",
                table: "SONG",
                column: "ID_ALBUM",
                principalTable: "ALBUM",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
