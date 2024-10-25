using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab5Part1.Migrations.Lab5Part1FluentUser
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FluentUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Title = table.Column<int>(type: "INTEGER", nullable: false),
                    Biography = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    age_of_user = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentUsers", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentUsers");
        }
    }
}
