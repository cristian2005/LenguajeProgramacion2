using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal.Migrations
{
    public partial class Secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Usuarios_CreadoPor",
                table: "Departamentos");

            migrationBuilder.AlterColumn<int>(
                name: "ModificadoPor",
                table: "Departamentos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CreadoPor",
                table: "Departamentos",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Departamentos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Usuarios_CreadoPor",
                table: "Departamentos",
                column: "CreadoPor",
                principalTable: "Usuarios",
                principalColumn: "Usuarioid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Usuarios_CreadoPor",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Departamentos");

            migrationBuilder.AlterColumn<int>(
                name: "ModificadoPor",
                table: "Departamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreadoPor",
                table: "Departamentos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Usuarios_CreadoPor",
                table: "Departamentos",
                column: "CreadoPor",
                principalTable: "Usuarios",
                principalColumn: "Usuarioid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
