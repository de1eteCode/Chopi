using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chopi.Modules.EFCore.Migrations
{
    public partial class addpassportmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PassportId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    SecondName = table.Column<string>(type: "varchar(50)", nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Series = table.Column<string>(type: "varchar(10)", nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", nullable: false),
                    ResidenceRegistration = table.Column<string>(type: "varchar(150)", nullable: false),
                    Citizenship = table.Column<string>(type: "varchar(100)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PassportId",
                table: "Users",
                column: "PassportId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Passports_PassportId",
                table: "Users",
                column: "PassportId",
                principalTable: "Passports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Passports_PassportId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropIndex(
                name: "IX_Users_PassportId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PassportId",
                table: "Users");
        }
    }
}
