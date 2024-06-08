using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtFusionStudio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfilePics_ImageExtensions_ImageExtId",
                table: "UserProfilePics");

            migrationBuilder.DropIndex(
                name: "IX_UserProfilePics_ImageExtId",
                table: "UserProfilePics");

            migrationBuilder.DropColumn(
                name: "ImageExtId",
                table: "UserProfilePics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageExtId",
                table: "UserProfilePics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfilePics_ImageExtId",
                table: "UserProfilePics",
                column: "ImageExtId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfilePics_ImageExtensions_ImageExtId",
                table: "UserProfilePics",
                column: "ImageExtId",
                principalTable: "ImageExtensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
