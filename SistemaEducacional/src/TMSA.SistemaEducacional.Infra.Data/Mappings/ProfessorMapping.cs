using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Professores;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class ProfessorMapping : EntityTypeConfiguration<Professor>
    {
        public override void Map(EntityTypeBuilder<Professor> builder)
        {
            builder.Ignore(p => p.CascadeMode);

            builder.Ignore(p => p.ValidationResult);

            builder.HasOne(f => f.Funcionario)
                .WithOne(p => p.Professor)
                .HasForeignKey<Professor>(p => p.FuncionarioId)
                .IsRequired(false);

            builder.HasOne(p => p.Presenca)
                .WithOne(pr => pr.Professor)
                .HasForeignKey<Professor>(pr => pr.PresencaId);

            builder.Property(p => p.GrauDeEnsino)
                .IsRequired();

            builder.ToTable("Professores");
        }
    }
}