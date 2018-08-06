using FluentValidation;
using System;
using TMSA.SistemaEducacional.Domain.Core.Models;

namespace TMSA.SistemaEducacional.Domain.Alunos
{
    public class Filiacao : Entity<Filiacao>
    {
        public Filiacao(
            string nomeDoPai,
            string cpfDoPai,
            string rgDoPai,
            string celularDoPai,
            string emailDoPai,
            DateTime dataDeNascimentoDoPai,
            string nomeDaMae,
            string cpfDaMae,
            string rgDaMae,
            DateTime dataDeNascimentoDamae,
            string celularDaMae,
            string emailDaMae)
        {
            NomeDoPai = nomeDoPai;
            CPFDoPai = cpfDoPai;
            RGDoPai = rgDoPai;
            CelularDoPai = celularDoPai;
            EmailDoPai = emailDoPai;
            DataDeNascimentoDoPai = dataDeNascimentoDoPai;
            NomeDaMae = nomeDaMae;
            CPFDaMae = cpfDaMae;
            RGDaMae = rgDaMae;
            DataDeNascimentoDaMae = dataDeNascimentoDamae;
            CelularDaMae = celularDaMae;
            EmailDaMae = emailDaMae;
        }

        //EF Construtor
        protected Filiacao() { }

        public string NomeDoPai { get; private set; }
        public string CPFDoPai { get; private set; }
        public string RGDoPai { get; private set; }
        public string CelularDoPai { get; private set; }
        public string EmailDoPai { get; private set; }
        public DateTime DataDeNascimentoDoPai { get; private set; }
        public string NomeDaMae { get; private set; }
        public string CPFDaMae { get; private set; }
        public string RGDaMae { get; private set; }
        public DateTime DataDeNascimentoDaMae { get; private set; }
        public string CelularDaMae { get; private set; }
        public string EmailDaMae { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarNomeDoPai();
            ValidarCPFDoPai();
            ValidarRGDoPai();
            ValidarCelularDoPai();
            ValidarEmailDoPai();
            ValidarDataDeNascimentoDoPai();
            ValidarNomeDaMae();
            ValidarCPFDaMae();
            ValidarRGDaMae();
            ValidarDataDeNascimentoDaMae();
            ValidarCelularDaMae();
            ValidarEmailDaMae();
            ValidationResult = Validate(this);
        }

        private void ValidarNomeDoPai()
        {
            RuleFor(c => c.NomeDoPai)
                .NotEmpty().WithMessage("Preencha o nome do pai.");
        }

        private void ValidarCPFDoPai()
        {
            RuleFor(c => c.CPFDoPai)
                .NotEmpty().WithMessage("Preencha o cpf")
                .Length(11).WithMessage("Preencha com 11 digitos.");
        }

        private void ValidarRGDoPai()
        {
            RuleFor(c => c.RGDoPai)
                .NotEmpty().WithMessage("Preencha o rg.");
        }

        private void ValidarCelularDoPai()
        {
            RuleFor(c => c.CelularDoPai)
                .NotEmpty().WithMessage("Preencha o celular");
        }

        private void ValidarEmailDoPai()
        {
            RuleFor(c => c.EmailDoPai)
                .EmailAddress().WithMessage("Preencha o e-mail.");
        }

        private void ValidarDataDeNascimentoDoPai()
        {
            RuleFor(c => c.DataDeNascimentoDoPai)
                .NotEmpty().WithMessage("Preencha a data de nascimento");
        }

        private void ValidarNomeDaMae()
        {
            RuleFor(c => c.NomeDaMae)
                .NotEmpty().WithMessage("Preencha o nome da mãe.");
        }

        private void ValidarCPFDaMae()
        {
            RuleFor(c => c.CPFDaMae)
                .NotEmpty().WithMessage("Preencha o cpf.");
        }

        private void ValidarRGDaMae()
        {
            RuleFor(c => c.RGDaMae)
                .NotEmpty().WithMessage("Preencha o rg.");
        }

        private void ValidarDataDeNascimentoDaMae()
        {
            RuleFor(c => c.DataDeNascimentoDaMae)
                .NotEmpty().WithMessage("Preencha data de nacimento da mãe.");
        }

        private void ValidarCelularDaMae()
        {
            RuleFor(c => c.CelularDaMae)
                .NotEmpty().WithMessage("Preencha o celular.");
        }

        private void ValidarEmailDaMae()
        {
            RuleFor(c => c.EmailDaMae)
                .EmailAddress().WithMessage("Preencha o e-mail.");
        }
        #endregion
    }
}