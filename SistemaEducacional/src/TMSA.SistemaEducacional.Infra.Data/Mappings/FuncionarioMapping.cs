using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Funcionarios;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class FuncionarioMapping : EntityTypeConfiguration<Funcionario>
    {
        public override void Map(EntityTypeBuilder<Funcionario> builder)
        {
            builder.Ignore(f => f.CascadeMode);

            builder.Ignore(f => f.ValidationResult);

            builder.Property(f => f.Salario)
                .IsRequired();

            builder.Property(f => f.Profissao)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("varchar(60)");

            builder.Property(f => f.DataDeAdmissao)
                .IsRequired();

            builder.Property(f => f.DataDeDemissao)
                .IsRequired(false);

            builder.HasOne(p => p.PessoaFisica)
                .WithOne(f => f.Funcionario)
                .HasForeignKey<Funcionario>(f => f.PessoaFisicaId);

            builder.ToTable("Funcionarios");
        }
    }
}