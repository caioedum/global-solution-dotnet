using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnergyLinkGlobalSolution.Migrations
{
    /// <inheritdoc />
    public partial class ExecuteProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENTIDADE_BASE",
                columns: table => new
                {
                    ID_ENTIDADE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTIDADE_BASE", x => x.ID_ENTIDADE);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO_ENERGYLINK",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_USUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SOBRENOME_USUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CPF_USUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EMAIL_USUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SENHA_USUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TELEFONE_USUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO_ENERGYLINK", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "MONITORAMENTO_ENERGIA",
                columns: table => new
                {
                    ID_MONITORAMENTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_ENTIDADE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DATA_MONITORAMENTO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ENERGIA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TIPO_MONITORAMENTO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MONITORAMENTO_ENERGIA", x => x.ID_MONITORAMENTO);
                    table.ForeignKey(
                        name: "FK_MONITORAMENTO_ENERGIA_ENTIDADE_BASE_ID_ENTIDADE",
                        column: x => x.ID_ENTIDADE,
                        principalTable: "ENTIDADE_BASE",
                        principalColumn: "ID_ENTIDADE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MONITORAMENTO_ENERGIA_ID_ENTIDADE",
                table: "MONITORAMENTO_ENERGIA",
                column: "ID_ENTIDADE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MONITORAMENTO_ENERGIA");

            migrationBuilder.DropTable(
                name: "USUARIO_ENERGYLINK");

            migrationBuilder.DropTable(
                name: "ENTIDADE_BASE");
        }
    }
}
