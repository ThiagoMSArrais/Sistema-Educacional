using FluentValidation;
using System;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Funcionarios;

namespace TMSA.SistemaEducacional.Domain.Pessoas
{
    public class PessoaFisica : Entity<PessoaFisica>
    {
        public PessoaFisica(
            DateTime dataDeNascimento,
            string cpf,
            string rg,
            DateTime dataDeEmissaoRG,
            string expedicaoDoRG,
            EstadoCivil estadoCivil,
            GrauEscolar grauEscolar)
        {
            DataDeNascimento = dataDeNascimento;
            CPF = cpf;
            RG = rg;
            DataDeEmissaoRG = dataDeEmissaoRG;
            ExpedicaoDoRG = expedicaoDoRG;
            EstadoCivil = estadoCivil;
            GrauEscolar = grauEscolar;
        }

        //EF Construtor
        protected PessoaFisica() { }

        public DateTime DataDeNascimento { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public DateTime DataDeEmissaoRG { get; private set; }
        public string ExpedicaoDoRG { get; private set; }
        public EstadoCivil? EstadoCivil { get; private set; }
        public GrauEscolar? GrauEscolar { get; private set; }
        public Guid PessoaId { get; private set; }
        public Guid? FuncionarioID { get; private set; }

        // EF Propriedades Navegação
        public virtual Pessoa Pessoa { get; private set; }
        public virtual Funcionario Funcionario { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarDataDeNascimento();
            ValidarCPF();
            ValidarRG();
            ValidarDataDeEmissaoRG();
            ValidarExpedicaoRG();
            ValidarEstadoCivil();
            ValidarGrauEscolar();
            ValidationResult = Validate(this);
        }

        private void ValidarDataDeNascimento()
        {
            RuleFor(c => c.DataDeNascimento)
                .NotEmpty().WithMessage("Preencha a data de nascimento.");
        }

        private void ValidarCPF()
        {
            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("Preencha o CPF.")
                .Length(11).WithMessage("Preencha o CPF somente com 11 digitos.");
        }

        private void ValidarRG()
        {
            RuleFor(c => c.RG)
                .NotEmpty().WithMessage("Preencha o RG.");
        }

        private void ValidarDataDeEmissaoRG()
        {
            RuleFor(c => c.DataDeEmissaoRG)
                .NotEmpty().WithMessage("Preencha a data de emissao do RG.");
        }

        private void ValidarExpedicaoRG()
        {
            RuleFor(c => c.ExpedicaoDoRG)
                .NotEmpty().WithMessage("Preencha a expedição do RG.");
        }

        private void ValidarEstadoCivil()
        {
            RuleFor(c => c.EstadoCivil)
                .NotNull().WithMessage("Selecione um estado civil.");
        }

        private void ValidarGrauEscolar()
        {
            RuleFor(c => c.GrauEscolar)
                .NotNull().WithMessage("Selecione um grau escolar.");
        }
        #endregion
    }
}