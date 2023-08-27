using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Keychain.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableSecret : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Secrets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: false),
                    Password = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: false),
                    Iv = table.Column<byte[]>(type: "bytea", nullable: false),
                    LastPasswordChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secrets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Secrets");
        }
    }
}
