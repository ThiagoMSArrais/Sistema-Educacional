using FluentValidation;
using TMSA.SistemaEducacional.Domain.Core.Models;

namespace TMSA.SistemaEducacional.Domain.Financeiros
{
    public class DadosBancario : Entity<DadosBancario>
    {
        public DadosBancario(
            int codigoDoBanco,
            int agencia,
            int conta,
            TipoDeConta tipoDeConta,
            string nomeDoBanco)
        {
            CodigoDoBanco = codigoDoBanco;
            Agencia = agencia;
            Conta = conta;
            TipoDeConta = TipoDeConta;
            NomeDoBanco = nomeDoBanco;
        }

        public int CodigoDoBanco { get; private set; }
        public int Agencia { get; private set; }
        public int Conta { get; private set; }
        public TipoDeConta TipoDeConta { get; private set; }
        public string NomeDoBanco { get; private set; }

        //EF Construtor
        protected DadosBancario() { }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarCodigoDoBanco();
            ValidarAgencia();
            ValidarConta();
            ValidarTipoDeConta();
            ValidarNomeDoBanco();
            ValidationResult = Validate(this);
        }

        private void ValidarCodigoDoBanco()
        {
            RuleFor(c => c.CodigoDoBanco)
                .NotEmpty().WithMessage("Preencha o código do banco.");
        }

        private void ValidarAgencia()
        {
            RuleFor(c => c.Agencia)
                .NotEmpty().WithMessage("Preencha a agência.");
        }

        private void ValidarConta()
        {
            RuleFor(c => c.Conta)
                .NotEmpty().WithMessage("Preencha a conta.");
        }

        private void ValidarTipoDeConta()
        {
            RuleFor(c => c.TipoDeConta)
                .NotNull().WithMessage("Selecione o tipo de conta.");
        }

        private void ValidarNomeDoBanco()
        {
            RuleFor(c => c.NomeDoBanco)
                .NotEmpty().WithMessage("Preencha o nome do banco.");
        }
        #endregion
    }
}