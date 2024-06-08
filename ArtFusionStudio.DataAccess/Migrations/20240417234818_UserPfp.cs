using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtFusionStudio.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserPfp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageExtensions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Extension = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageExtensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfilePics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageExtId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfilePics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfilePics_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfilePics_ImageExtensions_ImageExtId",
                        column: x => x.ImageExtId,
                        principalTable: "ImageExtensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ImageExtensions",
                columns: new[] { "Id", "Extension" },
                values: new object[,]
                {
                    { 1, "png" },
                    { 2, "jpg" },
                    { 3, "jpeg" },
                    { 4, "bmp" },
                    { 5, "webp" },
                    { 6, "tif" },
                    { 7, "tiff" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfilePics_ImageExtId",
                table: "UserProfilePics",
                column: "ImageExtId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfilePics_UserId",
                table: "UserProfilePics",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfilePics");

            migrationBuilder.DropTable(
                name: "ImageExtensions");
        }
    }
}
