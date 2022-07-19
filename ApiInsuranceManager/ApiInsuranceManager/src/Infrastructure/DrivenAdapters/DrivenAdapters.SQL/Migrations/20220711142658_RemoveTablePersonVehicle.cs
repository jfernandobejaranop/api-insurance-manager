using Microsoft.EntityFrameworkCore.Migrations;

namespace DrivenAdapters.SQL.Migrations
{
    public partial class RemoveTablePersonVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonVehicle");

            migrationBuilder.AddColumn<int>(
                name: "Id_Person",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Id_Person",
                table: "Vehicle",
                column: "Id_Person");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Person_Id_Person",
                table: "Vehicle",
                column: "Id_Person",
                principalTable: "Person",
                principalColumn: "IdPerson",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Person_Id_Person",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_Id_Person",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Id_Person",
                table: "Vehicle");

            migrationBuilder.CreateTable(
                name: "PersonVehicle",
                columns: table => new
                {
                    Id_Person_Vehicle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Person = table.Column<int>(type: "int", nullable: false),
                    Id_Vehicle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonVehicle", x => x.Id_Person_Vehicle);
                    table.ForeignKey(
                        name: "FK_PersonVehicle_Person_Id_Person",
                        column: x => x.Id_Person,
                        principalTable: "Person",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonVehicle_Vehicle_Id_Vehicle",
                        column: x => x.Id_Vehicle,
                        principalTable: "Vehicle",
                        principalColumn: "Id_Vehicle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonVehicle_Id_Person",
                table: "PersonVehicle",
                column: "Id_Person");

            migrationBuilder.CreateIndex(
                name: "IX_PersonVehicle_Id_Vehicle",
                table: "PersonVehicle",
                column: "Id_Vehicle");
        }
    }
}
