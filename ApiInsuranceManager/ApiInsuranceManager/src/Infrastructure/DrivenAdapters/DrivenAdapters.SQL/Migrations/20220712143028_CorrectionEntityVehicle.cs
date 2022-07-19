using Microsoft.EntityFrameworkCore.Migrations;

namespace DrivenAdapters.SQL.Migrations
{
    public partial class CorrectionEntityVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Brand_Id_Brand",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_Id_Brand",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Id_Brand",
                table: "Vehicle");

            migrationBuilder.AddColumn<string>(
                name: "Carriage",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carriage",
                table: "Vehicle");

            migrationBuilder.AddColumn<int>(
                name: "Id_Brand",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Id_Brand",
                table: "Vehicle",
                column: "Id_Brand");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Brand_Id_Brand",
                table: "Vehicle",
                column: "Id_Brand",
                principalTable: "Brand",
                principalColumn: "Id_Brand",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
