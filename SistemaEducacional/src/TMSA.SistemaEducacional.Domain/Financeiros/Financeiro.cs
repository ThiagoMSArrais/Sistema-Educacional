using FluentValidation;
using System;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Matriculas;

namespace TMSA.SistemaEducacional.Domain.Financeiros
{
    public class Financeiro : Entity<Financeiro>
    {
        public Financeiro(
            StatusFinanceiro statusFinanceiro,
            FormaDePagamentos formaDePagamentos,
            decimal valorMensal,
            bool desconto,
            decimal valorDesconto)
        {
            StatusFinanceiro = statusFinanceiro;
            FormaDePagamentos = formaDePagamentos;
            ValorMensal = valorMensal;
            Desconto = desconto;
            ValorDesconto = valorDesconto;
        }

        public StatusFinanceiro StatusFinanceiro { get; private set; }
        public FormaDePagamentos FormaDePagamentos { get; private set; }
        public decimal ValorMensal { get; private set; }
        public bool Desconto { get; private set; }
        public decimal ValorDesconto { get; private set; }
        public Guid? ResponsavelFinanceiroId { get; private set; }
        public Guid? MatriculaId { get; private set; }

        //EF Construtor
        protected Financeiro() { }

        //EF Propriedades de Navegação
        public virtual ResponsavelFinanceiro ResponsavelFinanceiro { get; private set; }
        public virtual Matricula Matricula { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarFormaDePagamentos();
            ValidarValorMensal();
            ValidarValorDesconto();
            ValidationResult = Validate(this);
        }

        private void ValidarFormaDePagamentos()
        {
            RuleFor(c => c.FormaDePagamentos)
                .NotNull().WithMessage("Selecione a forma de pagamento.");
        }

        private void ValidarValorMensal()
        {
            RuleFor(c => c.ValorMensal)
                .NotEmpty().WithMessage("Preencha o valor mensal.");
        }

        private void ValidarValorDesconto()
        {
            if (Desconto)
                RuleFor(c => c.ValorDesconto)
                    .Null().When(c => Desconto)
                    .WithMessage("Não tem desconto.");

            if (!Desconto)
                RuleFor(c => c.ValorDesconto)
                    .NotNull().When(c => c.Desconto == false)
                    .WithMessage("Preencha o valor desconto.");
        }
        #endregion
    }
}