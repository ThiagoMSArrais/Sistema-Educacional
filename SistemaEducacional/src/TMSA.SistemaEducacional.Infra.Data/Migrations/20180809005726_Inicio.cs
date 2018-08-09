using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TMSA.SistemaEducacional.Infra.Data.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartoesDeCreditos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    NumeroDoCartao = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    CVV = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    BandeiraDoCartao = table.Column<int>(nullable: false),
                    ResponsavelFinanceiroId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartoesDeCreditos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DadosBancarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CodigoDoBanco = table.Column<int>(maxLength: 3, nullable: false),
                    Agencia = table.Column<int>(maxLength: 4, nullable: false),
                    Conta = table.Column<int>(nullable: false),
                    DigitoVerificador = table.Column<int>(nullable: false),
                    TipoDeConta = table.Column<int>(nullable: false),
                    NomeDoBanco = table.Column<string>(maxLength: 100, nullable: false),
                    ResponsavelFinanceiroId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosBancarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DiaDaSemana = table.Column<int>(nullable: false),
                    Turma = table.Column<int>(maxLength: 3, nullable: false),
                    PresencaId = table.Column<Guid>(nullable: true),
                    ProvaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Numero = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Complemento = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Municipio = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    UF = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    CEP = table.Column<string>(nullable: false),
                    PessoaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Financeiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StatusFinanceiro = table.Column<int>(nullable: false),
                    FormaDePagamentos = table.Column<int>(nullable: false),
                    ValorMensal = table.Column<decimal>(nullable: false),
                    Desconto = table.Column<bool>(nullable: false),
                    ValorDesconto = table.Column<decimal>(nullable: false),
                    ResponsavelFinanceiroId = table.Column<Guid>(nullable: true),
                    MatriculaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    DDD = table.Column<string>(maxLength: 3, nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    EnderecoId = table.Column<Guid>(nullable: true),
                    PessoaFisicaId = table.Column<Guid>(nullable: true),
                    PessoaJuridicaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PessoasFisicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeNascimento = table.Column<DateTime>(nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    RG = table.Column<string>(nullable: false),
                    DataDeEmissaoRG = table.Column<DateTime>(nullable: false),
                    ExpedicaoDoRG = table.Column<string>(nullable: false),
                    EstadoCivil = table.Column<int>(nullable: false),
                    GrauEscolar = table.Column<int>(nullable: false),
                    PessoaId = table.Column<Guid>(nullable: false),
                    FuncionarioID = table.Column<Guid>(nullable: true),
                    AlunoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasFisicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoasFisicas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoasJuridicas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(13)", maxLength: 14, nullable: false),
                    InscricaoEstadutal = table.Column<string>(nullable: false),
                    NomeFantasia = table.Column<string>(nullable: false),
                    RazaoSocial = table.Column<string>(nullable: false),
                    PessoaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoasJuridicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoasJuridicas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Salario = table.Column<decimal>(nullable: false),
                    Profissao = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    DataDeAdmissao = table.Column<DateTime>(nullable: false),
                    DataDeDemissao = table.Column<DateTime>(nullable: true),
                    PessoaFisicaId = table.Column<Guid>(nullable: true),
                    ProfessorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_PessoasFisicas_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoasFisicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResponsaveisFinanceiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DadosBancariosId = table.Column<Guid>(nullable: true),
                    CartaoDeCreditoId = table.Column<Guid>(nullable: true),
                    PessoaJuridicaId = table.Column<Guid>(nullable: true),
                    PessoaFisicaId = table.Column<Guid>(nullable: true),
                    FinanceiroId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsaveisFinanceiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResponsaveisFinanceiros_CartoesDeCreditos_CartaoDeCreditoId",
                        column: x => x.CartaoDeCreditoId,
                        principalTable: "CartoesDeCreditos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponsaveisFinanceiros_DadosBancarios_DadosBancariosId",
                        column: x => x.DadosBancariosId,
                        principalTable: "DadosBancarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponsaveisFinanceiros_Financeiros_FinanceiroId",
                        column: x => x.FinanceiroId,
                        principalTable: "Financeiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponsaveisFinanceiros_PessoasFisicas_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoasFisicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResponsaveisFinanceiros_PessoasJuridicas_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "PessoasJuridicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MatriculaId = table.Column<Guid>(nullable: true),
                    FiliacaoId = table.Column<Guid>(nullable: true),
                    PresencaId = table.Column<Guid>(nullable: true),
                    PessoaFisicaId = table.Column<Guid>(nullable: true),
                    ProvaId = table.Column<Guid>(nullable: true),
                    DisciplinaId = table.Column<Guid>(nullable: true),
                    ResponsavelFinanceiroId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alunos_PessoasFisicas_PessoaFisicaId",
                        column: x => x.PessoaFisicaId,
                        principalTable: "PessoasFisicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alunos_ResponsaveisFinanceiros_ResponsavelFinanceiroId",
                        column: x => x.ResponsavelFinanceiroId,
                        principalTable: "ResponsaveisFinanceiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filiacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeDoPai = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    CPFDoPai = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    RGDoPai = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    CelularDoPai = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    EmailDoPai = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    DataDeNascimentoDoPai = table.Column<DateTime>(nullable: false),
                    NomeDaMae = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    CPFDaMae = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    RGDaMae = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    DataDeNascimentoDaMae = table.Column<DateTime>(nullable: false),
                    CelularDaMae = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    EmailDaMae = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    AlunoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filiacoes_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    StatusMatricula = table.Column<int>(nullable: false),
                    Turno = table.Column<int>(nullable: false),
                    FinanceiroId = table.Column<Guid>(nullable: true),
                    AlunoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matriculas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matriculas_Financeiros_FinanceiroId",
                        column: x => x.FinanceiroId,
                        principalTable: "Financeiros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Presencas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    StatusPresenca = table.Column<int>(nullable: false),
                    DescricaoDaAusencia = table.Column<string>(type: "varchar(240)", maxLength: 240, nullable: false),
                    AbonoPorAusencia = table.Column<bool>(nullable: false),
                    DescricaoDoAbono = table.Column<string>(nullable: true),
                    DisciplinaId = table.Column<Guid>(nullable: true),
                    ProfessorId = table.Column<Guid>(nullable: true),
                    AlunoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presencas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presencas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presencas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FuncionarioId = table.Column<Guid>(nullable: true),
                    PresencaId = table.Column<Guid>(nullable: true),
                    GrauDeEnsino = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professores_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Professores_Presencas_PresencaId",
                        column: x => x.PresencaId,
                        principalTable: "Presencas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Provas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NotaPrimeiroSemestre = table.Column<double>(nullable: true),
                    NotaSegundoSemestre = table.Column<double>(nullable: true),
                    MediaDoPrimeiroESegundoSemestre = table.Column<double>(nullable: true),
                    NotaFinal = table.Column<double>(nullable: true),
                    StatusAprovacao = table.Column<int>(nullable: false),
                    AlunoId = table.Column<Guid>(nullable: true),
                    DisciplinaId = table.Column<Guid>(nullable: true),
                    ProfessorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Provas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Provas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_DisciplinaId",
                table: "Alunos",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_PessoaFisicaId",
                table: "Alunos",
                column: "PessoaFisicaId",
                unique: true,
                filter: "[PessoaFisicaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ResponsavelFinanceiroId",
                table: "Alunos",
                column: "ResponsavelFinanceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Filiacoes_AlunoId",
                table: "Filiacoes",
                column: "AlunoId",
                unique: true,
                filter: "[AlunoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_PessoaFisicaId",
                table: "Funcionarios",
                column: "PessoaFisicaId",
                unique: true,
                filter: "[PessoaFisicaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas",
                column: "AlunoId",
                unique: true,
                filter: "[AlunoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_FinanceiroId",
                table: "Matriculas",
                column: "FinanceiroId",
                unique: true,
                filter: "[FinanceiroId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId",
                unique: true,
                filter: "[EnderecoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PessoasFisicas_PessoaId",
                table: "PessoasFisicas",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PessoasJuridicas_PessoaId",
                table: "PessoasJuridicas",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_AlunoId",
                table: "Presencas",
                column: "AlunoId",
                unique: true,
                filter: "[AlunoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Presencas_DisciplinaId",
                table: "Presencas",
                column: "DisciplinaId",
                unique: true,
                filter: "[DisciplinaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_FuncionarioId",
                table: "Professores",
                column: "FuncionarioId",
                unique: true,
                filter: "[FuncionarioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_PresencaId",
                table: "Professores",
                column: "PresencaId",
                unique: true,
                filter: "[PresencaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Provas_AlunoId",
                table: "Provas",
                column: "AlunoId",
                unique: true,
                filter: "[AlunoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Provas_DisciplinaId",
                table: "Provas",
                column: "DisciplinaId",
                unique: true,
                filter: "[DisciplinaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Provas_ProfessorId",
                table: "Provas",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisFinanceiros_CartaoDeCreditoId",
                table: "ResponsaveisFinanceiros",
                column: "CartaoDeCreditoId",
                unique: true,
                filter: "[CartaoDeCreditoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisFinanceiros_DadosBancariosId",
                table: "ResponsaveisFinanceiros",
                column: "DadosBancariosId",
                unique: true,
                filter: "[DadosBancariosId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisFinanceiros_FinanceiroId",
                table: "ResponsaveisFinanceiros",
                column: "FinanceiroId",
                unique: true,
                filter: "[FinanceiroId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisFinanceiros_PessoaFisicaId",
                table: "ResponsaveisFinanceiros",
                column: "PessoaFisicaId",
                unique: true,
                filter: "[PessoaFisicaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisFinanceiros_PessoaJuridicaId",
                table: "ResponsaveisFinanceiros",
                column: "PessoaJuridicaId",
                unique: true,
                filter: "[PessoaJuridicaId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filiacoes");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Provas");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Presencas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "ResponsaveisFinanceiros");

            migrationBuilder.DropTable(
                name: "CartoesDeCreditos");

            migrationBuilder.DropTable(
                name: "DadosBancarios");

            migrationBuilder.DropTable(
                name: "Financeiros");

            migrationBuilder.DropTable(
                name: "PessoasFisicas");

            migrationBuilder.DropTable(
                name: "PessoasJuridicas");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
