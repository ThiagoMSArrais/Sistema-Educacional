using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Matriculas;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class MatriculasMapping : EntityTypeConfiguration<Matricula>
    {
        public override void Map(EntityTypeBuilder<Matricula> builder)
        {
            builder.Ignore(m => m.CascadeMode);

            builder.Ignore(m => m.ValidationResult);

            builder.Property(m => m.DataCadastro)
                .IsRequired();

            builder.Property(m => m.Turno)
                .IsRequired();

            builder.Property(m => m.StatusMatricula)
                .IsRequired();

            builder.HasOne(f => f.Financeiro)
                .WithOne(m => m.Matricula)
                .HasForeignKey<Matricula>(m => m.FinanceiroId)
                .IsRequired(false);

            builder.HasOne(a => a.Aluno)
                .WithOne(m => m.Matricula)
                .HasForeignKey<Matricula>(m => m.AlunoId)
                .IsRequired(false);

            builder.ToTable("Matriculas");
        }
    }
}