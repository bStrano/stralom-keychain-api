using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keychain.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIvShareableSecrets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Iv",
                table: "ShareableSecrets",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iv",
                table: "ShareableSecrets");
        }
    }
}
