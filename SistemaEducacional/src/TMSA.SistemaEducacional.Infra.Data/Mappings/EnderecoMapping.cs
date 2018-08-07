using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Enderecos;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class EnderecoMapping : EntityTypeConfiguration<Endereco>
    {
        public override void Map(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            builder.Property(e => e.Complemento)
                .IsRequired(false);

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Municipio)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(e => e.CEP)
                .IsRequired();

            builder.Property(e => e.UF)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnType("varchar(2)");

            builder.Ignore(e => e.CascadeMode);

            builder.Ignore(e => e.ValidationResult);

            builder.HasOne(c => c.Pessoa)
                .WithOne(c => c.Endereco)
                .HasForeignKey<Endereco>(c => c.PessoaId)
                .IsRequired(false);

            builder.ToTable("Enderecos");
        }
    }
}