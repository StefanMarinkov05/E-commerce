using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtFusionStudio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserPfpExt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "UserProfilePics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "UserProfilePics");
        }
    }
}
