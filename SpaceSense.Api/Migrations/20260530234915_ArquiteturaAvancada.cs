using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceSense.Api.Migrations
{
    /// <inheritdoc />
    public partial class ArquiteturaAvancada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMPRESAS",
                columns: table => new
                {
                    empresa_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    empresa_nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    empresa_pais = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    endereco_rua = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    endereco_cidade = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    endereco_estado = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    endereco_cep = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESAS", x => x.empresa_id);
                });

            migrationBuilder.CreateTable(
                name: "ORBITAS",
                columns: table => new
                {
                    orbita_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    orbita_altitude_km = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    orbita_categoria = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    orbita_inclinacao = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORBITAS", x => x.orbita_id);
                });

            migrationBuilder.CreateTable(
                name: "PLATAFORMA",
                columns: table => new
                {
                    plataforma_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    plataforma_nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    plataforma_status = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLATAFORMA", x => x.plataforma_id);
                });

            migrationBuilder.CreateTable(
                name: "ObjetosEspaciais",
                columns: table => new
                {
                    objeto_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    velocidade = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    orbita_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetosEspaciais", x => x.objeto_id);
                    table.ForeignKey(
                        name: "FK_ObjetosEspaciais_ORBITAS_orbita_id",
                        column: x => x.orbita_id,
                        principalTable: "ORBITAS",
                        principalColumn: "orbita_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    usuario_nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    usuario_email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    usuario_senha = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    usuario_tipo = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    plataforma_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.usuario_id);
                    table.ForeignKey(
                        name: "FK_USUARIOS_PLATAFORMA_plataforma_id",
                        column: x => x.plataforma_id,
                        principalTable: "PLATAFORMA",
                        principalColumn: "plataforma_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DETRITO_ESPACIAL",
                columns: table => new
                {
                    objeto_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    detrito_tamanho = table.Column<decimal>(type: "decimal(4, 1)", nullable: false),
                    detrito_risco_colisao = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETRITO_ESPACIAL", x => x.objeto_id);
                    table.ForeignKey(
                        name: "FK_DETRITO_ESPACIAL_ObjetosEspaciais_objeto_id",
                        column: x => x.objeto_id,
                        principalTable: "ObjetosEspaciais",
                        principalColumn: "objeto_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SATELITES",
                columns: table => new
                {
                    objeto_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    satelite_nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    satelite_funcao = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    satelite_status = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    satelite_data_lancamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    empresa_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SATELITES", x => x.objeto_id);
                    table.ForeignKey(
                        name: "FK_SATELITES_EMPRESAS_empresa_id",
                        column: x => x.empresa_id,
                        principalTable: "EMPRESAS",
                        principalColumn: "empresa_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SATELITES_ObjetosEspaciais_objeto_id",
                        column: x => x.objeto_id,
                        principalTable: "ObjetosEspaciais",
                        principalColumn: "objeto_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALERTAS",
                columns: table => new
                {
                    alerta_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    alerta_nivel = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    alerta_descricao = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    alerta_data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    satelite_id = table.Column<int>(type: "INTEGER", nullable: false),
                    PLATAFORMA_plataforma_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALERTAS", x => x.alerta_id);
                    table.ForeignKey(
                        name: "FK_ALERTAS_PLATAFORMA_PLATAFORMA_plataforma_id",
                        column: x => x.PLATAFORMA_plataforma_id,
                        principalTable: "PLATAFORMA",
                        principalColumn: "plataforma_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ALERTAS_SATELITES_satelite_id",
                        column: x => x.satelite_id,
                        principalTable: "SATELITES",
                        principalColumn: "objeto_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALERTAS_PLATAFORMA_plataforma_id",
                table: "ALERTAS",
                column: "PLATAFORMA_plataforma_id");

            migrationBuilder.CreateIndex(
                name: "IX_ALERTAS_satelite_id",
                table: "ALERTAS",
                column: "satelite_id");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetosEspaciais_orbita_id",
                table: "ObjetosEspaciais",
                column: "orbita_id");

            migrationBuilder.CreateIndex(
                name: "IX_SATELITES_empresa_id",
                table: "SATELITES",
                column: "empresa_id");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_plataforma_id",
                table: "USUARIOS",
                column: "plataforma_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALERTAS");

            migrationBuilder.DropTable(
                name: "DETRITO_ESPACIAL");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "SATELITES");

            migrationBuilder.DropTable(
                name: "PLATAFORMA");

            migrationBuilder.DropTable(
                name: "EMPRESAS");

            migrationBuilder.DropTable(
                name: "ObjetosEspaciais");

            migrationBuilder.DropTable(
                name: "ORBITAS");
        }
    }
}
