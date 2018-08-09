using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Alunos;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class AlunoMapping : EntityTypeConfiguration<Aluno>
    {
        public override void Map(EntityTypeBuilder<Aluno> builder)
        {
            builder.Ignore(c => c.CascadeMode);

            builder.Ignore(c => c.ValidationResult);

            builder.HasOne(a => a.Matricula)
                .WithOne(m => m.Aluno)
                .HasForeignKey<Aluno>(a => a.MatriculaId)
                .IsRequired(false);

            builder.HasOne(a => a.Filiacao)
                .WithOne(f => f.Aluno)
                .HasForeignKey<Aluno>(f => f.FiliacaoId)
                .IsRequired(false);

            builder.HasOne(a => a.Presenca)
                .WithOne(p => p.Aluno)
                .HasForeignKey<Aluno>(p => p.PresencaId)
                .IsRequired(false);

            builder.HasOne(a => a.PessoaFisica)
                .WithOne(p => p.Aluno)
                .HasForeignKey<Aluno>(p => p.PessoaFisicaId)
                .IsRequired(false);

            builder.ToTable("Alunos");
        }
    }
}