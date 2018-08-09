using FluentValidation;
using System;
using TMSA.SistemaEducacional.Domain.Core.Models;

namespace TMSA.SistemaEducacional.Domain.Financeiros
{
    public class CartaoDeCredito : Entity<CartaoDeCredito>
    {
        public CartaoDeCredito(
            string nome,
            string numeroDoCartao,
            string cvv,
            BandeiraDoCartao bandeiraDoCartao)
        {
            Nome = nome;
            NumeroDoCartao = numeroDoCartao;
            CVV = cvv;
            BandeiraDoCartao = bandeiraDoCartao;
        }

        public string Nome { get; private set; }
        public string NumeroDoCartao { get; private set; }
        public string CVV { get; private set; }
        public BandeiraDoCartao BandeiraDoCartao { get; private set; }
        public Guid? ResponsavelFinanceiroId { get; private set; }

        //EF PROPRIEDADES DE NAVEGAÇÃO.
        public virtual ResponsavelFinanceiro ResponsavelFinanceiro { get; private set; }

        //EF Construtor
        protected CartaoDeCredito() { }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarNome();
            ValidarNumeroDoCartao();
            ValidarCVV();
            ValidarBandeiraDoCartao();
            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Preencha o nome.");
        }

        private void ValidarNumeroDoCartao()
        {
            RuleFor(c => c.NumeroDoCartao)
                .NotEmpty().WithMessage("Preencha o número do cartão.");
        }

        private void ValidarCVV()
        {
            RuleFor(c => c.CVV)
                .NotEmpty().WithMessage("Preencha o cvv.");
        }
        
        private void ValidarBandeiraDoCartao()
        {
            RuleFor(c => c.BandeiraDoCartao)
                .NotNull().WithMessage("Selecione a bandeira.");
        }
        #endregion
    }
}