using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keychain.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnHasPasswordShareableSecrets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasPassword",
                table: "ShareableSecrets",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPassword",
                table: "ShareableSecrets");
        }
    }
}
