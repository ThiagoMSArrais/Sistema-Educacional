using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Financeiros;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class ResponsavelFinanceiroMapping : EntityTypeConfiguration<ResponsavelFinanceiro>
    {
        public override void Map(EntityTypeBuilder<ResponsavelFinanceiro> builder)
        {
            builder.Ignore(r => r.ValidationResult);

            builder.Ignore(r => r.CascadeMode);

            builder.HasOne(d => d.DadosBancario)
                .WithOne(r => r.ResponsavelFinanceiro)
                .HasForeignKey<ResponsavelFinanceiro>(r => r.DadosBancariosId)
                .IsRequired(false);

            builder.HasOne(c => c.CartaoDeCredito)
                .WithOne(r => r.ResponsavelFinanceiro)
                .HasForeignKey<ResponsavelFinanceiro>(r => r.CartaoDeCreditoId)
                .IsRequired(false);

            builder.HasOne(p => p.PessoaJuridica)
                .WithOne(r => r.ResponsavelFinanceiro)
                .HasForeignKey<ResponsavelFinanceiro>(r => r.PessoaJuridicaId)
                .IsRequired(false);

            builder.HasOne(p => p.PessoaFisica)
                .WithOne(r => r.ResponsavelFinanceiro)
                .HasForeignKey<ResponsavelFinanceiro>(r => r.PessoaFisicaId);

            builder.HasOne(f => f.Financeiro)
                .WithOne(r => r.ResponsavelFinanceiro)
                .HasForeignKey<ResponsavelFinanceiro>(r => r.FinanceiroId);

            builder.ToTable("ResponsaveisFinanceiros");
        }
    }
}