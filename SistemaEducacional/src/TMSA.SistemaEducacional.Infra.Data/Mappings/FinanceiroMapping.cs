using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Financeiros;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class FinanceiroMapping : EntityTypeConfiguration<Financeiro>
    {
        public override void Map(EntityTypeBuilder<Financeiro> builder)
        {
            builder.Ignore(f => f.ValidationResult);

            builder.Ignore(f => f.CascadeMode);

            builder.Property(f => f.StatusFinanceiro)
                .IsRequired();

            builder.Property(f => f.FormaDePagamentos)
                .IsRequired();

            builder.Property(f => f.ValorMensal)
                .IsRequired();

            builder.Property(f => f.Desconto)
                .IsRequired();

            builder.HasOne(r => r.ResponsavelFinanceiro)
                .WithOne(f => f.Financeiro)
                .HasForeignKey<Financeiro>(f => f.ResponsavelFinanceiroId);

            builder.ToTable("Financeiros");
        }
    }
}