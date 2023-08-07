using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keychain.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBurnedAtShareableSecrets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BurnedAt",
                table: "ShareableSecrets",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BurnedAt",
                table: "ShareableSecrets");
        }
    }
}
