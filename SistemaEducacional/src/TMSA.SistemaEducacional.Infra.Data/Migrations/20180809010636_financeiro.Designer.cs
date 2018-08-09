﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TMSA.SistemaEducacional.Infra.Data.Context;

namespace TMSA.SistemaEducacional.Infra.Data.Migrations
{
    [DbContext(typeof(SistemaEducacionalContext))]
    [Migration("20180809010636_financeiro")]
    partial class financeiro
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Alunos.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("DisciplinaId");

                    b.Property<Guid?>("FiliacaoId");

                    b.Property<Guid?>("MatriculaId");

                    b.Property<Guid?>("PessoaFisicaId");

                    b.Property<Guid?>("PresencaId");

                    b.Property<Guid?>("ProvaId");

                    b.Property<Guid?>("ResponsavelFinanceiroId");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("PessoaFisicaId")
                        .IsUnique()
                        .HasFilter("[PessoaFisicaId] IS NOT NULL");

                    b.HasIndex("ResponsavelFinanceiroId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Alunos.Filiacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AlunoId");

                    b.Property<string>("CPFDaMae")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("CPFDoPai")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("CelularDaMae")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("CelularDoPai")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<DateTime>("DataDeNascimentoDaMae");

                    b.Property<DateTime>("DataDeNascimentoDoPai");

                    b.Property<string>("EmailDaMae")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("EmailDoPai")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("NomeDaMae")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("NomeDoPai")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("RGDaMae")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasMaxLength(14);

                    b.Property<string>("RGDoPai")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasMaxLength(14);

                    b.HasKey("Id");

                    b.HasIndex("AlunoId")
                        .IsUnique()
                        .HasFilter("[AlunoId] IS NOT NULL");

                    b.ToTable("Filiacoes");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Enderecos.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CEP")
                        .IsRequired();

                    b.Property<string>("Complemento");

                    b.Property<string>("Estado");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<Guid?>("PessoaId");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Financeiros.CartaoDeCredito", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BandeiraDoCartao");

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("varchar(4)")
                        .HasMaxLength(4);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("NumeroDoCartao")
                        .IsRequired()
                        .HasColumnType("varchar(16)")
                        .HasMaxLength(16);

                    b.Property<Guid?>("ResponsavelFinanceiroId");

                    b.HasKey("Id");

                    b.ToTable("CartoesDeCreditos");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Financeiros.DadosBancario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Agencia")
                        .HasMaxLength(4);

                    b.Property<int>("CodigoDoBanco")
                        .HasMaxLength(3);

                    b.Property<int>("Conta");

                    b.Property<int>("DigitoVerificador");

                    b.Property<string>("NomeDoBanco")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid?>("ResponsavelFinanceiroId");

                    b.Property<int>("TipoDeConta");

                    b.HasKey("Id");

                    b.ToTable("DadosBancarios");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Financeiros.Financeiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Desconto");

                    b.Property<int>("FormaDePagamentos");

                    b.Property<Guid?>("MatriculaId");

                    b.Property<Guid?>("ResponsavelFinanceiroId");

                    b.Property<int>("StatusFinanceiro");

                    b.Property<decimal>("ValorDesconto");

                    b.Property<decimal>("ValorMensal");

                    b.HasKey("Id");

                    b.ToTable("Financeiros");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Financeiros.ResponsavelFinanceiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CartaoDeCreditoId");

                    b.Property<Guid?>("DadosBancariosId");

                    b.Property<Guid?>("FinanceiroId");

                    b.Property<Guid?>("PessoaFisicaId");

                    b.Property<Guid?>("PessoaJuridicaId");

                    b.HasKey("Id");

                    b.HasIndex("CartaoDeCreditoId")
                        .IsUnique()
                        .HasFilter("[CartaoDeCreditoId] IS NOT NULL");

                    b.HasIndex("DadosBancariosId")
                        .IsUnique()
                        .HasFilter("[DadosBancariosId] IS NOT NULL");

                    b.HasIndex("FinanceiroId")
                        .IsUnique()
                        .HasFilter("[FinanceiroId] IS NOT NULL");

                    b.HasIndex("PessoaFisicaId")
                        .IsUnique()
                        .HasFilter("[PessoaFisicaId] IS NOT NULL");

                    b.HasIndex("PessoaJuridicaId")
                        .IsUnique()
                        .HasFilter("[PessoaJuridicaId] IS NOT NULL");

                    b.ToTable("ResponsaveisFinanceiros");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Funcionarios.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataDeAdmissao");

                    b.Property<DateTime?>("DataDeDemissao");

                    b.Property<Guid?>("PessoaFisicaId");

                    b.Property<Guid?>("ProfessorId");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<decimal>("Salario");

                    b.HasKey("Id");

                    b.HasIndex("PessoaFisicaId")
                        .IsUnique()
                        .HasFilter("[PessoaFisicaId] IS NOT NULL");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Matriculas.Disciplina", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DiaDaSemana");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid?>("PresencaId");

                    b.Property<Guid?>("ProvaId");

                    b.Property<int>("Turma")
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Matriculas.Matricula", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AlunoId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<Guid?>("FinanceiroId");

                    b.Property<int>("StatusMatricula");

                    b.Property<int>("Turno");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId")
                        .IsUnique()
                        .HasFilter("[AlunoId] IS NOT NULL");

                    b.HasIndex("FinanceiroId")
                        .IsUnique()
                        .HasFilter("[FinanceiroId] IS NOT NULL");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Pessoas.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Celular")
                        .IsRequired();

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<Guid?>("EnderecoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<Guid?>("PessoaFisicaId");

                    b.Property<Guid?>("PessoaJuridicaId");

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique()
                        .HasFilter("[EnderecoId] IS NOT NULL");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Pessoas.PessoaFisica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AlunoId");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataDeEmissaoRG");

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<int>("EstadoCivil");

                    b.Property<string>("ExpedicaoDoRG")
                        .IsRequired();

                    b.Property<Guid?>("FuncionarioID");

                    b.Property<int>("GrauEscolar");

                    b.Property<Guid>("PessoaId");

                    b.Property<string>("RG")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("PessoasFisicas");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Pessoas.PessoaJuridica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(13)")
                        .HasMaxLength(14);

                    b.Property<string>("InscricaoEstadutal")
                        .IsRequired();

                    b.Property<string>("NomeFantasia")
                        .IsRequired();

                    b.Property<Guid>("PessoaId");

                    b.Property<string>("RazaoSocial")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("PessoasJuridicas");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Presencas.Presenca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AbonoPorAusencia");

                    b.Property<Guid?>("AlunoId");

                    b.Property<DateTime>("Data");

                    b.Property<string>("DescricaoDaAusencia")
                        .IsRequired()
                        .HasColumnType("varchar(240)")
                        .HasMaxLength(240);

                    b.Property<string>("DescricaoDoAbono");

                    b.Property<Guid?>("DisciplinaId");

                    b.Property<Guid?>("ProfessorId");

                    b.Property<int>("StatusPresenca");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId")
                        .IsUnique()
                        .HasFilter("[AlunoId] IS NOT NULL");

                    b.HasIndex("DisciplinaId")
                        .IsUnique()
                        .HasFilter("[DisciplinaId] IS NOT NULL");

                    b.ToTable("Presencas");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Professores.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("FuncionarioId");

                    b.Property<int>("GrauDeEnsino");

                    b.Property<Guid?>("PresencaId");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId")
                        .IsUnique()
                        .HasFilter("[FuncionarioId] IS NOT NULL");

                    b.HasIndex("PresencaId")
                        .IsUnique()
                        .HasFilter("[PresencaId] IS NOT NULL");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Provas.Prova", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AlunoId");

                    b.Property<Guid?>("DisciplinaId");

                    b.Property<double?>("MediaDoPrimeiroESegundoSemestre");

                    b.Property<double?>("NotaFinal");

                    b.Property<double?>("NotaPrimeiroSemestre");

                    b.Property<double?>("NotaSegundoSemestre");

                    b.Property<Guid?>("ProfessorId");

                    b.Property<int>("StatusAprovacao");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId")
                        .IsUnique()
                        .HasFilter("[AlunoId] IS NOT NULL");

                    b.HasIndex("DisciplinaId")
                        .IsUnique()
                        .HasFilter("[DisciplinaId] IS NOT NULL");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Provas");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Alunos.Aluno", b =>
                {
                    b.HasOne("TMSA.SistemaEducacional.Domain.Matriculas.Disciplina")
                        .WithMany("Alunos")
                        .HasForeignKey("DisciplinaId");

                    b.HasOne("TMSA.SistemaEducacional.Domain.Pessoas.PessoaFisica", "PessoaFisica")
                        .WithOne("Aluno")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Alunos.Aluno", "PessoaFisicaId");

                    b.HasOne("TMSA.SistemaEducacional.Domain.Financeiros.ResponsavelFinanceiro")
                        .WithMany("AlunosBeneficiados")
                        .HasForeignKey("ResponsavelFinanceiroId");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Alunos.Filiacao", b =>
                {
                    b.HasOne("TMSA.SistemaEducacional.Domain.Alunos.Aluno", "Aluno")
                        .WithOne("Filiacao")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Alunos.Filiacao", "AlunoId");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Financeiros.ResponsavelFinanceiro", b =>
                {
                    b.HasOne("TMSA.SistemaEducacional.Domain.Financeiros.CartaoDeCredito", "CartaoDeCredito")
                        .WithOne("ResponsavelFinanceiro")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Financeiros.ResponsavelFinanceiro", "CartaoDeCreditoId");

                    b.HasOne("TMSA.SistemaEducacional.Domain.Financeiros.DadosBancario", "DadosBancario")
                        .WithOne("ResponsavelFinanceiro")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Financeiros.ResponsavelFinanceiro", "DadosBancariosId");

                    b.HasOne("TMSA.SistemaEducacional.Domain.Financeiros.Financeiro", "Financeiro")
                        .WithOne("ResponsavelFinanceiro")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Financeiros.ResponsavelFinanceiro", "FinanceiroId");

                    b.HasOne("TMSA.SistemaEducacional.Domain.Pessoas.PessoaFisica", "PessoaFisica")
                        .WithOne("ResponsavelFinanceiro")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Financeiros.ResponsavelFinanceiro", "PessoaFisicaId");

                    b.HasOne("TMSA.SistemaEducacional.Domain.Pessoas.PessoaJuridica", "PessoaJuridica")
                        .WithOne("ResponsavelFinanceiro")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Financeiros.ResponsavelFinanceiro", "PessoaJuridicaId");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Funcionarios.Funcionario", b =>
                {
                    b.HasOne("TMSA.SistemaEducacional.Domain.Pessoas.PessoaFisica", "PessoaFisica")
                        .WithOne("Funcionario")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Funcionarios.Funcionario", "PessoaFisicaId");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Matriculas.Matricula", b =>
                {
                    b.HasOne("TMSA.SistemaEducacional.Domain.Alunos.Aluno", "Aluno")
                        .WithOne("Matricula")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Matriculas.Matricula", "AlunoId");

                    b.HasOne("TMSA.SistemaEducacional.Domain.Financeiros.Financeiro", "Financeiro")
                        .WithOne("Matricula")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Matriculas.Matricula", "FinanceiroId");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Pessoas.Pessoa", b =>
                {
                    b.HasOne("TMSA.SistemaEducacional.Domain.Enderecos.Endereco", "Endereco")
                        .WithOne("Pessoa")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Pessoas.Pessoa", "EnderecoId");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Pessoas.PessoaFisica", b =>
                {
                    b.HasOne("TMSA.SistemaEducacional.Domain.Pessoas.Pessoa", "Pessoa")
                        .WithOne("PessoaFisica")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Pessoas.PessoaFisica", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Pessoas.PessoaJuridica", b =>
                {
                    b.HasOne("TMSA.SistemaEducacional.Domain.Pessoas.Pessoa", "Pessoa")
                        .WithOne("PessoaJuridica")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Pessoas.PessoaJuridica", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Presencas.Presenca", b =>
                {
                    b.HasOne("TMSA.SistemaEducacional.Domain.Alunos.Aluno", "Aluno")
                        .WithOne("Presenca")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Presencas.Presenca", "AlunoId");

                    b.HasOne("TMSA.SistemaEducacional.Domain.Matriculas.Disciplina", "Disciplina")
                        .WithOne("Presenca")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Presencas.Presenca", "DisciplinaId");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Professores.Professor", b =>
                {
                    b.HasOne("TMSA.SistemaEducacional.Domain.Funcionarios.Funcionario", "Funcionario")
                        .WithOne("Professor")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Professores.Professor", "FuncionarioId");

                    b.HasOne("TMSA.SistemaEducacional.Domain.Presencas.Presenca", "Presenca")
                        .WithOne("Professor")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Professores.Professor", "PresencaId");
                });

            modelBuilder.Entity("TMSA.SistemaEducacional.Domain.Provas.Prova", b =>
                {
                    b.HasOne("TMSA.SistemaEducacional.Domain.Alunos.Aluno", "Aluno")
                        .WithOne("Prova")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Provas.Prova", "AlunoId");

                    b.HasOne("TMSA.SistemaEducacional.Domain.Matriculas.Disciplina", "Disciplina")
                        .WithOne("Prova")
                        .HasForeignKey("TMSA.SistemaEducacional.Domain.Provas.Prova", "DisciplinaId");

                    b.HasOne("TMSA.SistemaEducacional.Domain.Professores.Professor")
                        .WithMany("Provas")
                        .HasForeignKey("ProfessorId");
                });
#pragma warning restore 612, 618
        }
    }
}
