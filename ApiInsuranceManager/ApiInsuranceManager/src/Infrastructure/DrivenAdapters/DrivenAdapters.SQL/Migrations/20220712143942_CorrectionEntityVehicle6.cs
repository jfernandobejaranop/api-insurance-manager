using Microsoft.EntityFrameworkCore.Migrations;

namespace DrivenAdapters.SQL.Migrations
{
    public partial class CorrectionEntityVehicle6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Brand",
                table: "Line",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Line_Id_Brand",
                table: "Line",
                column: "Id_Brand");

            migrationBuilder.AddForeignKey(
                name: "FK_Line_Brand_Id_Brand",
                table: "Line",
                column: "Id_Brand",
                principalTable: "Brand",
                principalColumn: "Id_Brand",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Line_Brand_Id_Brand",
                table: "Line");

            migrationBuilder.DropIndex(
                name: "IX_Line_Id_Brand",
                table: "Line");

            migrationBuilder.DropColumn(
                name: "Id_Brand",
                table: "Line");
        }
    }
}
