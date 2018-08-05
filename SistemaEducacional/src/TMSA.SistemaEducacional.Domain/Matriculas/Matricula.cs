using FluentValidation;
using System;
using TMSA.SistemaEducacional.Domain.Alunos;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Financeiros;

namespace TMSA.SistemaEducacional.Domain.Matriculas
{
    public class Matricula : Entity<Matricula>
    {

        public Matricula(
            DateTime dataCadastro,
            StatusMatricula statusMatricula,
            Turno turno)
        {
            Id = Guid.NewGuid();
            DataCadastro = dataCadastro;
            StatusMatricula = statusMatricula;
            Turno = turno;
        }

        // EF Construtor
        protected Matricula() { }

        public DateTime DataCadastro { get; private set; }
        public StatusMatricula? StatusMatricula { get; private set; }
        public Turno? Turno { get; private set; }
        public Guid? FinanceiroId { get; private set; }
        public Guid? AlunoId { get; private set; }

        // EF Propriedades de Navegação
        public virtual Financeiro Financeiro { get; private set; }
        public virtual Aluno Aluno { get; set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarDataCadastro();
            ValidarStatusMatricula();
            ValidarTurno();
            ValidationResult = Validate(this);
        }

        private void ValidarDataCadastro()
        {
            RuleFor(c => c.DataCadastro)
                .NotEmpty().WithMessage("Preencher a data do cadastro da matricula.");
        }

        private void ValidarStatusMatricula()
        {
            RuleFor(c => c.StatusMatricula)
                .NotNull().WithMessage("Selecione o status da matrícula.");
        }

        private void ValidarTurno()
        {
            RuleFor(c => c.Turno)
                .NotNull().WithMessage("Selecione o turno.");
        }
        #endregion
    }
}