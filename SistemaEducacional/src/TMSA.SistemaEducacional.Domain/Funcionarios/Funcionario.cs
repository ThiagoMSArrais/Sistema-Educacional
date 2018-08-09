using FluentValidation;
using System;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Pessoas;
using TMSA.SistemaEducacional.Domain.Professores;

namespace TMSA.SistemaEducacional.Domain.Funcionarios
{
    public class Funcionario : Entity<Funcionario>
    {
        public Funcionario(
            Decimal salario,
            string profissao,
            DateTime dataDeAdmissao,
            DateTime? dataDeDemissao)
        {
            Salario = salario;
            Profissao = profissao;
            DataDeAdmissao = dataDeAdmissao;
            DataDeDemissao = dataDeDemissao;
        }

        public Decimal Salario { get; private set; }
        public string Profissao { get; private set; }
        public DateTime DataDeAdmissao { get; private set; }
        public DateTime? DataDeDemissao { get; private set; }
        public Guid? PessoaFisicaId { get; private set; }
        public Guid? ProfessorId { get; private set; }

        //EF Construtor
        protected Funcionario() { }

        //EF Propriedades de Navegação
        public virtual PessoaFisica PessoaFisica { get; private set; }
        public virtual Professor Professor { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarSalario();
            ValidarProfissao();
            ValidarDataDeAdmissao();
            ValidationResult = Validate(this);
        }

        private void ValidarSalario()
        {
            RuleFor(c => c.Salario)
                .NotEmpty().WithMessage("Preencha o salário.");
        }

        private void ValidarProfissao()
        {
            RuleFor(c => c.Profissao)
                .NotEmpty().WithMessage("Preencher a profissão.");
        }

        private void ValidarDataDeAdmissao()
        {
            RuleFor(c => c.DataDeAdmissao)
                .NotEmpty().WithMessage("Preencher a data de admissão.");
        }
        #endregion
    }
}