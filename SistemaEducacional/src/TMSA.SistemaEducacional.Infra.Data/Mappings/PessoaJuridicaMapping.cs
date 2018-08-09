using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Pessoas;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class PessoaJuridicaMapping : EntityTypeConfiguration<PessoaJuridica>
    {
        public override void Map(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder.Ignore(p => p.CascadeMode);

            builder.Ignore(p => p.ValidationResult);

            builder.Property(p => p.CNPJ)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnType("varchar(13)");

            builder.Property(p => p.InscricaoEstadutal)
                .IsRequired();

            builder.Property(p => p.NomeFantasia)
                .IsRequired();

            builder.Property(p => p.RazaoSocial)
                .IsRequired();

            builder.HasOne(p => p.Pessoa)
                .WithOne(pj => pj.PessoaJuridica)
                .HasForeignKey<PessoaJuridica>(pj => pj.PessoaId);

            builder.ToTable("PessoasJuridicas");

        }
    }
}