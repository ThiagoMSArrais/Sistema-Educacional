using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMSA.SistemaEducacional.Domain.Alunos;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class FiliacaoMapping : EntityTypeConfiguration<Filiacao>
    {
        public override void Map(EntityTypeBuilder<Filiacao> builder)
        {
            builder.Ignore(f => f.CascadeMode);

            builder.Ignore(f => f.ValidationResult);

            builder.Property(f => f.NomeDoPai)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(f => f.CPFDoPai)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("varchar(11)");

            builder.Property(f => f.RGDoPai)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnType("varchar(14)");

            builder.Property(f => f.CelularDoPai)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            builder.Property(f => f.EmailDoPai)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(f => f.DataDeNascimentoDoPai)
                .IsRequired();

            builder.Property(f => f.NomeDaMae)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(f => f.CPFDaMae)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("varchar(11)");

            builder.Property(f => f.RGDaMae)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnType("varchar(14)");

            builder.Property(f => f.CelularDaMae)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnType("varchar(10)");

            builder.Property(f => f.EmailDaMae)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            builder.Property(f => f.DataDeNascimentoDaMae)
                .IsRequired();

            builder.HasOne(a => a.Aluno)
                .WithOne(f => f.Filiacao)
                .HasForeignKey<Filiacao>(f => f.AlunoId);

            builder.ToTable("Filiacoes");
        }
    }
}