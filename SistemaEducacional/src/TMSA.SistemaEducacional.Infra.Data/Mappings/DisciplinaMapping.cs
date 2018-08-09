using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TMSA.SistemaEducacional.Domain.Matriculas;
using TMSA.SistemaEducacional.Infra.Data.Extensions;

namespace TMSA.SistemaEducacional.Infra.Data.Mappings
{
    public class DisciplinaMapping : EntityTypeConfiguration<Disciplina>
    {
        public override void Map(EntityTypeBuilder<Disciplina> builder)
        {
            builder.Ignore(d => d.CascadeMode);

            builder.Ignore(d => d.ValidationResult);

            builder.Property(d => d.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(d => d.DiaDaSemana)
                .IsRequired();

            builder.Property(d => d.Turma)
                .IsRequired()
                .HasMaxLength(3);


            builder.ToTable("Disciplinas");
        }
    }
}
