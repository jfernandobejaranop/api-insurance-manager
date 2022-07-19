using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DrivenAdapters.SQL.Migrations
{
    public partial class addCompleteShema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Eps",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brand",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InsuranceType",
                columns: table => new
                {
                    Id_Insurance_Type = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceType", x => x.Id_Insurance_Type);
                });

            migrationBuilder.CreateTable(
                name: "Line",
                columns: table => new
                {
                    Id_Line = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.Id_Line);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceValues",
                columns: table => new
                {
                    Id_Insurance_Values = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Insurance_Type = table.Column<int>(type: "int", nullable: false),
                    BaseValue = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceValues", x => x.Id_Insurance_Values);
                    table.ForeignKey(
                        name: "FK_InsuranceValues_InsuranceType_Id_Insurance_Type",
                        column: x => x.Id_Insurance_Type,
                        principalTable: "InsuranceType",
                        principalColumn: "Id_Insurance_Type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    Id_Request = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Person = table.Column<int>(type: "int", nullable: false),
                    Id_Insurance_Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id_Request);
                    table.ForeignKey(
                        name: "FK_Request_InsuranceType_Id_Insurance_Type",
                        column: x => x.Id_Insurance_Type,
                        principalTable: "InsuranceType",
                        principalColumn: "Id_Insurance_Type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id_Vehicle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Brand = table.Column<int>(type: "int", nullable: false),
                    Id_Line = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id_Vehicle);
                    table.ForeignKey(
                        name: "FK_Vehicle_Brand_Id_Brand",
                        column: x => x.Id_Brand,
                        principalTable: "Brand",
                        principalColumn: "Id_Brand",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Line_Id_Line",
                        column: x => x.Id_Line,
                        principalTable: "Line",
                        principalColumn: "Id_Line",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_InsuranceValues_Id_Insurance_Type",
                table: "InsuranceValues",
                column: "Id_Insurance_Type");

            migrationBuilder.CreateIndex(
                name: "IX_PersonVehicle_Id_Person",
                table: "PersonVehicle",
                column: "Id_Person");

            migrationBuilder.CreateIndex(
                name: "IX_PersonVehicle_Id_Vehicle",
                table: "PersonVehicle",
                column: "Id_Vehicle");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Id_Insurance_Type",
                table: "Request",
                column: "Id_Insurance_Type");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Id_Brand",
                table: "Vehicle",
                column: "Id_Brand");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Id_Line",
                table: "Vehicle",
                column: "Id_Line");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceValues");

            migrationBuilder.DropTable(
                name: "PersonVehicle");

            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "InsuranceType");

            migrationBuilder.DropTable(
                name: "Line");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Eps",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");
        }
    }
}
