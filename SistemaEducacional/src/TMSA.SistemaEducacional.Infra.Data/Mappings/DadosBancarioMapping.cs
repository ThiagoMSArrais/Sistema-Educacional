using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Financeiros;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class DadosBancarioMapping : EntityTypeConfiguration<DadosBancario>
    {
        public override void Map(EntityTypeBuilder<DadosBancario> builder)
        {
            builder.Ignore(d => d.CascadeMode);

            builder.Ignore(d => d.ValidationResult);

            builder.Property(d => d.CodigoDoBanco)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(d => d.Agencia)
                .IsRequired()
                .HasMaxLength(4);

            builder.Property(d => d.Conta)
                .IsRequired();

            builder.Property(d => d.NomeDoBanco)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.DigitoVerificador)
                .IsRequired();

            builder.HasOne(r => r.ResponsavelFinanceiro)
                .WithOne(d => d.DadosBancario)
                .HasForeignKey<DadosBancario>(d => d.ResponsavelFinanceiroId);

            builder.ToTable("DadosBancarios");
                
        }
    }
}