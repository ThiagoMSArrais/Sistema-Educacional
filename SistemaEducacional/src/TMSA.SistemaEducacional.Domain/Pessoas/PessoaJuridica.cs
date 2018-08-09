using FluentValidation;
using System;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Financeiros;

namespace TMSA.SistemaEducacional.Domain.Pessoas
{
    public class PessoaJuridica : Entity<PessoaJuridica>
    {
        public PessoaJuridica(
            string cnpj,
            string inscricaoEstadual,
            string nomeFantasia,
            string razaoSocial)
        {
            CNPJ = cnpj;
            InscricaoEstadutal = inscricaoEstadual;
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
        }

        //EF Construtor
        protected PessoaJuridica() { }

        public string CNPJ { get; private set; }
        public string InscricaoEstadutal { get; private set; }
        public string NomeFantasia { get; private set; }
        public string RazaoSocial { get; private set; }
        public Guid PessoaId { get; private set; }

        // EF Propriedade de Navegação
        public virtual Pessoa Pessoa { get; private set; }
        public virtual ResponsavelFinanceiro ResponsavelFinanceiro { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarCNPJ();
            ValidarInscricaoEstadual();
            ValidarNomeFantasia();
            ValidarRazaoSocial();
            ValidationResult = Validate(this);
        }

        private void ValidarCNPJ()
        {
            RuleFor(c => c.CNPJ)
                .NotEmpty().WithMessage("Preencha o CNPJ.");
        }

        private void ValidarInscricaoEstadual()
        {
            RuleFor(c => c.InscricaoEstadutal)
                .NotEmpty().WithMessage("Preencha a inscrição estadual.");
        }

        private void ValidarNomeFantasia()
        {
            RuleFor(c => c.NomeFantasia)
                .NotEmpty().WithMessage("Preencha o nome fantasia.");
        }

        private void ValidarRazaoSocial()
        {
            RuleFor(c => c.RazaoSocial)
                .NotEmpty().WithMessage("Preencha a razão social.");
        }
        #endregion
    }
}