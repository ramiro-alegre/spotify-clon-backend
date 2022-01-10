using Microsoft.EntityFrameworkCore.Migrations;

namespace spotify_clone_backend.Migrations
{
    public partial class DbInitializer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Duration_DurationId",
                table: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Duration",
                table: "Duration");

            migrationBuilder.RenameTable(
                name: "Duration",
                newName: "Durations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Durations",
                table: "Durations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Durations_DurationId",
                table: "Tracks",
                column: "DurationId",
                principalTable: "Durations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Durations_DurationId",
                table: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Durations",
                table: "Durations");

            migrationBuilder.RenameTable(
                name: "Durations",
                newName: "Duration");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Duration",
                table: "Duration",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Duration_DurationId",
                table: "Tracks",
                column: "DurationId",
                principalTable: "Duration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
