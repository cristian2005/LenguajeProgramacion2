using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal.Migrations
{
    public partial class UltimateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incidentes",
                columns: table => new
                {
                    IncidenteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    UsuarioReporteId = table.Column<int>(nullable: false),
                    UsuarioAsignadoId = table.Column<int>(nullable: false),
                    PrioridadId = table.Column<int>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 200, nullable: true),
                    Descripcion = table.Column<string>(maxLength: 2147483647, nullable: true),
                    Fecha_Cierre = table.Column<DateTime>(nullable: false),
                    ComentarioCierre = table.Column<string>(maxLength: 500, nullable: true),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidentes", x => x.IncidenteId);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    PuestoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: true),
                    ModificadoPor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.PuestoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Usuarioid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    PuestoId = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(maxLength: 100, nullable: true),
                    Cedula = table.Column<string>(maxLength: 11, nullable: true),
                    Correo = table.Column<string>(maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(maxLength: 15, nullable: true),
                    Fecha_Nacimiento = table.Column<DateTime>(nullable: false),
                    NombreUsuario = table.Column<string>(maxLength: 100, nullable: true),
                    Contrasena = table.Column<string>(maxLength: 500, nullable: true),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: true),
                    ModificadoPor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Usuarioid);
                    table.ForeignKey(
                        name: "FK_Usuarios_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "PuestoId");
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: true),
                    ModificadoPor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                    table.ForeignKey(
                        name: "FK_Departamentos_Usuarios_CreadoPor",
                        column: x => x.CreadoPor,
                        principalTable: "Usuarios",
                        principalColumn: "Usuarioid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departamentos_Usuarios_ModificadoPor",
                        column: x => x.ModificadoPor,
                        principalTable: "Usuarios",
                        principalColumn: "Usuarioid");
                });

            migrationBuilder.CreateTable(
                name: "HistorialIncidentes",
                columns: table => new
                {
                    HistorialIncidenteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    IncidenteId = table.Column<int>(nullable: false),
                    Comentario = table.Column<string>(maxLength: 500, nullable: true),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialIncidentes", x => x.HistorialIncidenteId);
                    table.ForeignKey(
                        name: "FK_HistorialIncidentes_Usuarios_CreadoPor",
                        column: x => x.CreadoPor,
                        principalTable: "Usuarios",
                        principalColumn: "Usuarioid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialIncidentes_Incidentes_IncidenteId",
                        column: x => x.IncidenteId,
                        principalTable: "Incidentes",
                        principalColumn: "IncidenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialIncidentes_Usuarios_ModificadoPor",
                        column: x => x.ModificadoPor,
                        principalTable: "Usuarios",
                        principalColumn: "Usuarioid");
                });

            migrationBuilder.CreateTable(
                name: "Slas",
                columns: table => new
                {
                    SlaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: true),
                    CantidadHoras = table.Column<int>(nullable: false),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slas", x => x.SlaId);
                    table.ForeignKey(
                        name: "FK_Slas_Usuarios_CreadoPor",
                        column: x => x.CreadoPor,
                        principalTable: "Usuarios",
                        principalColumn: "Usuarioid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slas_Usuarios_ModificadoPor",
                        column: x => x.ModificadoPor,
                        principalTable: "Usuarios",
                        principalColumn: "Usuarioid");
                });

            migrationBuilder.CreateTable(
                name: "Prioridades",
                columns: table => new
                {
                    PrioridadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    SlaId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: true),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridades", x => x.PrioridadId);
                    table.ForeignKey(
                        name: "FK_Prioridades_Usuarios_CreadoPor",
                        column: x => x.CreadoPor,
                        principalTable: "Usuarios",
                        principalColumn: "Usuarioid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prioridades_Usuarios_ModificadoPor",
                        column: x => x.ModificadoPor,
                        principalTable: "Usuarios",
                        principalColumn: "Usuarioid");
                    table.ForeignKey(
                        name: "FK_Prioridades_Slas_SlaId",
                        column: x => x.SlaId,
                        principalTable: "Slas",
                        principalColumn: "SlaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_CreadoPor",
                table: "Departamentos",
                column: "CreadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_ModificadoPor",
                table: "Departamentos",
                column: "ModificadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialIncidentes_CreadoPor",
                table: "HistorialIncidentes",
                column: "CreadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialIncidentes_IncidenteId",
                table: "HistorialIncidentes",
                column: "IncidenteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialIncidentes_ModificadoPor",
                table: "HistorialIncidentes",
                column: "ModificadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_CreadoPor",
                table: "Incidentes",
                column: "CreadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_DepartamentoId",
                table: "Incidentes",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_ModificadoPor",
                table: "Incidentes",
                column: "ModificadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_PrioridadId",
                table: "Incidentes",
                column: "PrioridadId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_UsuarioAsignadoId",
                table: "Incidentes",
                column: "UsuarioAsignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_UsuarioReporteId",
                table: "Incidentes",
                column: "UsuarioReporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prioridades_CreadoPor",
                table: "Prioridades",
                column: "CreadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Prioridades_ModificadoPor",
                table: "Prioridades",
                column: "ModificadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Prioridades_SlaId",
                table: "Prioridades",
                column: "SlaId");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_CreadoPor",
                table: "Puestos",
                column: "CreadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_DepartamentoId",
                table: "Puestos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_ModificadoPor",
                table: "Puestos",
                column: "ModificadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Slas_CreadoPor",
                table: "Slas",
                column: "CreadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Slas_ModificadoPor",
                table: "Slas",
                column: "ModificadoPor");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PuestoId",
                table: "Usuarios",
                column: "PuestoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Usuarios_CreadoPor",
                table: "Incidentes",
                column: "CreadoPor",
                principalTable: "Usuarios",
                principalColumn: "Usuarioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Usuarios_ModificadoPor",
                table: "Incidentes",
                column: "ModificadoPor",
                principalTable: "Usuarios",
                principalColumn: "Usuarioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Usuarios_UsuarioAsignadoId",
                table: "Incidentes",
                column: "UsuarioAsignadoId",
                principalTable: "Usuarios",
                principalColumn: "Usuarioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Usuarios_UsuarioReporteId",
                table: "Incidentes",
                column: "UsuarioReporteId",
                principalTable: "Usuarios",
                principalColumn: "Usuarioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Departamentos_DepartamentoId",
                table: "Incidentes",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Prioridades_PrioridadId",
                table: "Incidentes",
                column: "PrioridadId",
                principalTable: "Prioridades",
                principalColumn: "PrioridadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Puestos_Usuarios_CreadoPor",
                table: "Puestos",
                column: "CreadoPor",
                principalTable: "Usuarios",
                principalColumn: "Usuarioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Puestos_Usuarios_ModificadoPor",
                table: "Puestos",
                column: "ModificadoPor",
                principalTable: "Usuarios",
                principalColumn: "Usuarioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Puestos_Departamentos_DepartamentoId",
                table: "Puestos",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId");

            migrationBuilder.Sql("create TRIGGER AfterINSERTTrigger_Dep on Departamentos FOR INSERT AS DECLARE @id INT SELECT @id = ins.DepartamentoId FROM INSERTED ins; Update Departamentos set Id = @id where DepartamentoId = @id");
            migrationBuilder.Sql("CREATE TRIGGER AfterINSERTTrigger_PUES on Puestos FOR INSERT AS DECLARE @id INT SELECT @id = ins.PuestoId FROM INSERTED ins; Update Puestos set Id = @id where PuestoId = @id");
            migrationBuilder.Sql("CREATE TRIGGER AfterINSERTTrigger_historial on [HistorialIncidentes] FOR INSERT AS DECLARE @id INT SELECT @id = ins.HistorialIncidenteId FROM INSERTED ins;Update[HistorialIncidentes] set Id = @id where HistorialIncidenteId = @id");
            migrationBuilder.Sql("CREATE TRIGGER AfterINSERTTrigger_Incident on [Incidentes] FOR INSERT AS DECLARE @id INT SELECT @id = ins.IncidenteId FROM INSERTED ins; Update[Incidentes] set Id = @id where IncidenteId = @id");
            migrationBuilder.Sql("CREATE TRIGGER AfterINSERTTrigger_Prioridades on [Prioridades] FOR INSERT AS DECLARE @id INT SELECT @id = ins.PrioridadId FROM INSERTED ins; Update[Prioridades] set Id = @id where PrioridadId = @id");
            migrationBuilder.Sql("CREATE TRIGGER AfterINSERTTrigger_slas on Slas FOR INSERT AS DECLARE @id INT SELECT @id = ins.SlaId FROM INSERTED ins; Update Slas set Id = @id where SlaId = @id");
            migrationBuilder.Sql("CREATE TRIGGER AfterINSERTTrigger_usuarios on Usuarios FOR INSERT AS DECLARE @id INT SELECT @id = ins.Usuarioid FROM INSERTED ins; Update Usuarios set Id = @id where Usuarioid = @id");
            migrationBuilder.Sql("CREATE TRIGGER INSERTTrigger_HistorialIncidentes on incidentes FOR INSERT, update AS DECLARE @id INT declare @comentario varchar(500) declare @estatus varchar(2) declare @creado int declare @modificado int SELECT @id = ins.IncidenteId FROM INSERTED ins; SELECT @comentario = ins.ComentarioCierre FROM INSERTED ins; SELECT @estatus = ins.Estatus FROM INSERTED ins;SELECT @creado = ins.CreadoPor FROM INSERTED ins; SELECT @modificado = ins.ModificadoPor FROM INSERTED ins;INSERT INTO HistorialIncidentes(Id, IncidenteId, Comentario, Estatus, FechaRegistro, FechaModificacion, CreadoPor, ModificadoPor, Borrado) values(0, @id, @comentario, @estatus, GETDATE(), GETDATE(), @creado, @modificado, 0)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Usuarios_CreadoPor",
                table: "Departamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Usuarios_ModificadoPor",
                table: "Departamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Puestos_Usuarios_CreadoPor",
                table: "Puestos");

            migrationBuilder.DropForeignKey(
                name: "FK_Puestos_Usuarios_ModificadoPor",
                table: "Puestos");

            migrationBuilder.DropTable(
                name: "HistorialIncidentes");

            migrationBuilder.DropTable(
                name: "Incidentes");

            migrationBuilder.DropTable(
                name: "Prioridades");

            migrationBuilder.DropTable(
                name: "Slas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.Sql("Drop trigger AfterINSERTTrigger_Dep");
            migrationBuilder.Sql("Drop trigger AfterINSERTTrigger_PUES");
            migrationBuilder.Sql("Drop trigger AfterINSERTTrigger_historial");
            migrationBuilder.Sql("Drop trigger AfterINSERTTrigger_Incident");
            migrationBuilder.Sql("Drop trigger AfterINSERTTrigger_Prioridades");
            migrationBuilder.Sql("Drop trigger AfterINSERTTrigger_slas");
            migrationBuilder.Sql("Drop trigger AfterINSERTTrigger_usuarios");
            migrationBuilder.Sql("Drop trigger INSERTTrigger_HistorialIncidentes");
        }
    }
}
