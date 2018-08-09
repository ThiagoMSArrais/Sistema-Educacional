using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Pessoas;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class PessoaMapping : EntityTypeConfiguration<Pessoa>
    {
        public override void Map(EntityTypeBuilder<Pessoa> builder)
        {
            builder.Ignore(p => p.CascadeMode);

            builder.Ignore(p => p.ValidationResult);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.DDD)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(p => p.Telefone)
                .IsRequired();

            builder.Property(p => p.Celular)
                .IsRequired();

            builder.HasOne(e => e.Endereco)
                .WithOne(p => p.Pessoa)
                .HasForeignKey<Pessoa>(p => p.EnderecoId);

            builder.ToTable("Pessoas");
        }
    }
}