using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GenAPI.Migrations.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Debtor",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(100)", maxLength: 255, nullable: false),
                    Frontnames = table.Column<string>(type: "nvarchar(100)", maxLength: 85, nullable: true),
                    Surnames = table.Column<string>(type: "nvarchar(100)", maxLength: 85, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IDCard = table.Column<string>(type: "nvarchar(100)", maxLength: 255, nullable: true),
                    DueDebt = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    DebtToDue = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    PositiveBalance = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debtor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Debtor",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");
        }
    }
}
