using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Presencas;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class PresencaMapping : EntityTypeConfiguration<Presenca>
    {
        public override void Map(EntityTypeBuilder<Presenca> builder)
        {
            builder.Ignore(p => p.CascadeMode);

            builder.Ignore(p => p.ValidationResult);

            builder.Property(p => p.Data)
                .IsRequired();

            builder.Property(p => p.StatusPresenca)
                .IsRequired();

            builder.Property(p => p.DescricaoDaAusencia)
                .IsRequired()
                .HasMaxLength(240)
                .HasColumnType("varchar(240)");

            builder.Property(p => p.AbonoPorAusencia)
                .IsRequired();

            builder.Property(p => p.DescricaoDoAbono)
                .IsRequired(false);

            builder.HasOne(d => d.Disciplina)
                .WithOne(p => p.Presenca)
                .HasForeignKey<Presenca>(p => p.DisciplinaId)
                .IsRequired(false);

            builder.HasOne(p => p.Professor)
                .WithOne(pr => pr.Presenca)
                .HasForeignKey<Presenca>(p => p.ProfessorId)
                .IsRequired(false);

            builder.HasOne(a => a.Aluno)
                .WithOne(p => p.Presenca)
                .HasForeignKey<Presenca>(p => p.AlunoId)
                .IsRequired(false);

            builder.ToTable("Presencas");
        }
    }
}