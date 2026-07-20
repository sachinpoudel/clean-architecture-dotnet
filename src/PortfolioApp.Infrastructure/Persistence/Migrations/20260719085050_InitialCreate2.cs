using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioApp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutMe_ProfilePicture",
                table: "Users",
                newName: "AboutMe_ProfilePictureUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutMe_ProfilePictureUrl",
                table: "Users",
                newName: "AboutMe_ProfilePicture");
        }
    }
}
