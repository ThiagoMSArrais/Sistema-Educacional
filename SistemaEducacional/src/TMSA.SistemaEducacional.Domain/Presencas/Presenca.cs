using FluentValidation;
using System;
using TMSA.SistemaEducacional.Domain.Alunos;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Matriculas;
using TMSA.SistemaEducacional.Domain.Professores;

namespace TMSA.SistemaEducacional.Domain.Presencas
{
    public class Presenca : Entity<Presenca>
    {

        public Presenca(
            DateTime data,
            StatusPresenca statusPresenca)
        {
            Id = Guid.NewGuid();
            Data = data;
            StatusPresenca = statusPresenca;
        }

        private Presenca() { }

        public DateTime Data { get; private set; }
        public StatusPresenca StatusPresenca { get; private set; }
        public string DescricaoDaAusencia { get; private set; }
        public bool AbonoPorAusencia { get; private set; }
        public string DescricaoDoAbono { get; private set; }
        public Guid? DisciplinaId { get; private set; }
        public Guid? ProfessorId { get; private set; }
        public Guid? AlunoId { get; private set; }

        // EF Propriedade da Navegação
        public virtual Disciplina Disciplina { get; private set; }
        public virtual Professor Professor { get; private set; }
        public virtual Aluno Aluno { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarData();
            ValidarStatusPresenca();
            ValidationResult = Validate(this);
        }

        private void ValidarData()
        {
            RuleFor(c => c.Data)
                .NotEmpty().WithMessage("A data deve estar preenchida.");
        }

        private void ValidarStatusPresenca()
        {
            RuleFor(c => c.StatusPresenca)
                .NotEmpty().WithMessage("O Status de Presença deve ser selecionado.");
        }

        #endregion

        public static class PresencaFactory
        {
            public static Presenca NovaPresencaCompleta(Guid id, StatusPresenca statusPresenca, string descricaoDaAusencia, bool abonoPorAusencia, string descricaoDoAbono, Guid disciplinaId, Guid alunoId, Guid professorId)
            {
                var presenca = new Presenca()
                {
                    Id = id,
                    StatusPresenca = statusPresenca,
                    DescricaoDaAusencia = descricaoDaAusencia,
                    AbonoPorAusencia = abonoPorAusencia,
                    DescricaoDoAbono = descricaoDoAbono,
                    DisciplinaId = disciplinaId,
                    AlunoId = alunoId,
                    ProfessorId = professorId
                };

                return presenca;
            }
        }
    }
}