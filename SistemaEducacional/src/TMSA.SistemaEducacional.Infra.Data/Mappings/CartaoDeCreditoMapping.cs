using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Financeiros;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class CartaoDeCreditoMapping : EntityTypeConfiguration<CartaoDeCredito>
    {
        public override void Map(EntityTypeBuilder<CartaoDeCredito> builder)
        {
            builder.Ignore(c => c.CascadeMode);

            builder.Ignore(c => c.ValidationResult);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.NumeroDoCartao)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnType("varchar(16)");

            builder.Property(c => c.CVV)
                .IsRequired()
                .HasMaxLength(4)
                .HasColumnType("varchar(4)");

            builder.Property(c => c.BandeiraDoCartao)
                .IsRequired();

            builder.HasOne(r => r.ResponsavelFinanceiro)
                .WithOne(c => c.CartaoDeCredito)
                .HasForeignKey<CartaoDeCredito>(c => c.ResponsavelFinanceiroId)
                .IsRequired(false);

            builder.ToTable("CartoesDeCreditos");
        }
    }
}