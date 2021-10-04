using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.API.Migrations
{
    public partial class initMysql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Matricula = table.Column<int>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Registro = table.Column<int>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinhas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PrerequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinhas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinhas_Disciplinhas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinhas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinhas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2021, 10, 4, 12, 57, 33, 649, DateTimeKind.Local).AddTicks(7897), new DateTime(2005, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" },
                    { 2, true, null, new DateTime(2021, 10, 4, 12, 57, 33, 649, DateTimeKind.Local).AddTicks(9480), new DateTime(2005, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" },
                    { 3, true, null, new DateTime(2021, 10, 4, 12, 57, 33, 649, DateTimeKind.Local).AddTicks(9594), new DateTime(2005, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" },
                    { 4, true, null, new DateTime(2021, 10, 4, 12, 57, 33, 649, DateTimeKind.Local).AddTicks(9606), new DateTime(2005, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" },
                    { 5, true, null, new DateTime(2021, 10, 4, 12, 57, 33, 649, DateTimeKind.Local).AddTicks(9613), new DateTime(2005, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" },
                    { 6, true, null, new DateTime(2021, 10, 4, 12, 57, 33, 649, DateTimeKind.Local).AddTicks(9625), new DateTime(2005, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" },
                    { 7, true, null, new DateTime(2021, 10, 4, 12, 57, 33, 649, DateTimeKind.Local).AddTicks(9630), new DateTime(2005, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas da Informação" },
                    { 3, "Ciência da Informação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2021, 10, 4, 12, 57, 33, 642, DateTimeKind.Local).AddTicks(7150), "Lauro", 1, "Oliveira", "12345688" },
                    { 2, true, null, new DateTime(2021, 10, 4, 12, 57, 33, 643, DateTimeKind.Local).AddTicks(9329), "Roberto", 2, "Soares", "54689954" },
                    { 3, true, null, new DateTime(2021, 10, 4, 12, 57, 33, 643, DateTimeKind.Local).AddTicks(9436), "Ronaldo", 3, "Marconi", "32145678" },
                    { 4, true, null, new DateTime(2021, 10, 4, 12, 57, 33, 643, DateTimeKind.Local).AddTicks(9442), "Rodrigo", 4, "Carvalho", "12345678" },
                    { 5, true, null, new DateTime(2021, 10, 4, 12, 57, 33, 643, DateTimeKind.Local).AddTicks(9444), "Alexandre", 5, "Montana", "32145678" }
                });

            migrationBuilder.InsertData(
                table: "Disciplinhas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 3, "Matemática", null, 1 },
                    { 3, 0, 3, "Física", null, 2 },
                    { 4, 0, 1, "Português", null, 3 },
                    { 5, 0, 1, "Inglês", null, 4 },
                    { 6, 0, 2, "Inglês", null, 4 },
                    { 7, 0, 3, "Inglês", null, 4 },
                    { 8, 0, 1, "Programação", null, 5 },
                    { 9, 0, 2, "Programação", null, 5 },
                    { 10, 0, 3, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1867), null },
                    { 4, 5, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1883), null },
                    { 2, 5, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1873), null },
                    { 1, 5, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1865), null },
                    { 7, 4, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1900), null },
                    { 6, 4, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1894), null },
                    { 5, 4, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1885), null },
                    { 4, 4, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1882), null },
                    { 1, 4, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1842), null },
                    { 7, 3, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1898), null },
                    { 5, 5, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1886), null },
                    { 6, 3, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1891), null },
                    { 7, 2, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1897), null },
                    { 6, 2, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1889), null },
                    { 3, 2, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1876), null },
                    { 2, 2, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1869), null },
                    { 1, 2, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1355), null },
                    { 7, 1, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1895), null },
                    { 6, 1, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1888), null },
                    { 4, 1, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1880), null },
                    { 3, 1, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1874), null },
                    { 3, 3, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1878), null },
                    { 7, 5, null, new DateTime(2021, 10, 4, 12, 57, 33, 650, DateTimeKind.Local).AddTicks(1901), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinhas_CursoId",
                table: "Disciplinhas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinhas_PrerequisitoId",
                table: "Disciplinhas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinhas_ProfessorId",
                table: "Disciplinhas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinhas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
