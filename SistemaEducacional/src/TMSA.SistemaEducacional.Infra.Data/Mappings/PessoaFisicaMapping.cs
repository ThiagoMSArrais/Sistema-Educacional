using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Pessoas;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class PessoaFisicaMapping : EntityTypeConfiguration<PessoaFisica>
    {
        public override void Map(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.Ignore(p => p.CascadeMode);

            builder.Ignore(p => p.ValidationResult);

            builder.Property(p => p.DataDeNascimento)
                .IsRequired();

            builder.Property(p => p.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(p => p.RG)
                .IsRequired();

            builder.Property(p => p.ExpedicaoDoRG)
                .IsRequired();

            builder.Property(p => p.DataDeEmissaoRG)
                .IsRequired();

            builder.Property(p => p.EstadoCivil)
                .IsRequired();

            builder.Property(p => p.GrauEscolar)
                .IsRequired();

            builder.HasOne(p => p.Pessoa)
                .WithOne(pf => pf.PessoaFisica)
                .HasForeignKey<PessoaFisica>(pf => pf.PessoaId);

            builder.ToTable("PessoasFisicas");
        }
    }
}