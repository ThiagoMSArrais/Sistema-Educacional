using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using TMSA.SistemaEducacional.Domain.Alunos;
using TMSA.SistemaEducacional.Domain.Enderecos;
using TMSA.SistemaEducacional.Domain.Financeiros;
using TMSA.SistemaEducacional.Domain.Funcionarios;
using TMSA.SistemaEducacional.Domain.Matriculas;
using TMSA.SistemaEducacional.Domain.Pessoas;
using TMSA.SistemaEducacional.Domain.Presencas;
using TMSA.SistemaEducacional.Domain.Professores;
using TMSA.SistemaEducacional.Domain.Provas;
using TMSA.SistemaEducacional.Infra.Data.Mappings;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Context
{
    public class SistemaEducacionalContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Filiacao> Filiacoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<CartaoDeCredito> CartoesDeCreditos { get; set; }
        public DbSet<DadosBancario> DadosBancarios { get; set; }
        public DbSet<Financeiro> Financeiros { get; set; }
        public DbSet<ResponsavelFinanceiro> ResponsaveisFinanceiros { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<Presenca> Presencas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Prova> Provas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new EnderecoMapping());
            modelBuilder.AddConfiguration(new AlunoMapping());
            modelBuilder.AddConfiguration(new FiliacaoMapping());
            modelBuilder.AddConfiguration(new CartaoDeCreditoMapping());
            modelBuilder.AddConfiguration(new DadosBancarioMapping());
            modelBuilder.AddConfiguration(new FinanceiroMapping());
            modelBuilder.AddConfiguration(new ResponsavelFinanceiroMapping());
            modelBuilder.AddConfiguration(new FuncionarioMapping());
            modelBuilder.AddConfiguration(new DisciplinaMapping());
            modelBuilder.AddConfiguration(new MatriculasMapping());
            modelBuilder.AddConfiguration(new PessoaMapping());
            modelBuilder.AddConfiguration(new PessoaFisicaMapping());
            modelBuilder.AddConfiguration(new PessoaJuridicaMapping());
            modelBuilder.AddConfiguration(new PresencaMapping());
            modelBuilder.AddConfiguration(new ProfessorMapping());
            modelBuilder.AddConfiguration(new ProvaMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}