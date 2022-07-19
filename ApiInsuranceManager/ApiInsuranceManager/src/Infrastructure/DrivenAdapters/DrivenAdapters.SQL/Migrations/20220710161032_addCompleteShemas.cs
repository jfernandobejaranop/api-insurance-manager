using Microsoft.EntityFrameworkCore.Migrations;

namespace DrivenAdapters.SQL.Migrations
{
    public partial class addCompleteShemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Request_Id_Person",
                table: "Request",
                column: "Id_Person");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Person_Id_Person",
                table: "Request",
                column: "Id_Person",
                principalTable: "Person",
                principalColumn: "IdPerson",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Person_Id_Person",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_Id_Person",
                table: "Request");
        }
    }
}
