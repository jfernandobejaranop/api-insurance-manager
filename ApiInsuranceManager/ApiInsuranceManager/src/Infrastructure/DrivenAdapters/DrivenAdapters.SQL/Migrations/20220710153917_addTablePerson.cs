using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrivenAdapters.SQL.Migrations
{
    public partial class addTablePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Id_Eps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.IdPerson);
                    table.ForeignKey(
                        name: "FK_Person_Eps_Id_Eps",
                        column: x => x.Id_Eps,
                        principalTable: "Eps",
                        principalColumn: "Id_Eps",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_Id_Eps",
                table: "Person",
                column: "Id_Eps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
