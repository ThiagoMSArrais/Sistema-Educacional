using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Provas;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class ProvaMapping : EntityTypeConfiguration<Prova>
    {
        public override void Map(EntityTypeBuilder<Prova> builder)
        {
            builder.Ignore(p => p.CascadeMode);

            builder.Ignore(p => p.ValidationResult);

            builder.Property(p => p.NotaPrimeiroSemestre)
                .IsRequired(false);

            builder.Property(p => p.NotaSegundoSemestre)
                .IsRequired(false);

            builder.Property(p => p.MediaDoPrimeiroESegundoSemestre)
                .IsRequired(false);

            builder.Property(p => p.NotaFinal)
                .IsRequired(false);

            builder.HasOne(a => a.Aluno)
                .WithOne(p => p.Prova)
                .HasForeignKey<Prova>(p => p.AlunoId)
                .IsRequired(false);

            builder.HasOne(d => d.Disciplina)
                .WithOne(p => p.Prova)
                .HasForeignKey<Prova>(p => p.DisciplinaId);

            builder.ToTable("Provas");
        }
    }
}