using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Funcionarios;
using TMSA.SistemaEducacional.Domain.Matriculas;
using TMSA.SistemaEducacional.Domain.Presencas;
using TMSA.SistemaEducacional.Domain.Provas;

namespace TMSA.SistemaEducacional.Domain.Professores
{
    public class Professor : Entity<Professor>
    {
        public Professor(
            GrauDeEnsino grauDeEnsino,
            List<Disciplina> disciplinas)
        {
            GrauDeEnsino = grauDeEnsino;
            Disciplinas = disciplinas;
        }

        //EF Construtor
        protected Professor() { }

        public Guid? FuncionarioId { get; private set; }
        public Guid? PresencaId { get; private set; }
        public GrauDeEnsino GrauDeEnsino { get; private set; }
        [NotMapped]
        public List<Disciplina> Disciplinas { get; private set; }

        //EF Propriedade da Navegação
        public virtual Funcionario Funcionario { get; private set; }
        public virtual Presenca Presenca { get; private set; }
        public virtual ICollection<Prova> Provas { get; private set; }
        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarGrauDeEnsino();
            ValidationResult = Validate(this);
        }

        private void ValidarGrauDeEnsino()
        {
            RuleFor(c => c.GrauDeEnsino)
                .NotNull().WithMessage("Selecione o grau de ensino.");
        }

        #endregion
    }
}