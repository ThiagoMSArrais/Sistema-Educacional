using FluentValidation;
using System;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Pessoas;

namespace TMSA.SistemaEducacional.Domain.Enderecos
{
    public class Endereco : Entity<Endereco>
    {
        public Endereco(
            string logradouro,
            int numero,
            string complemento,
            string bairro,
            string municipio,
            string estado,
            string uf,
            string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Municipio = municipio;
            Estado = estado;
            UF = uf;
            CEP = cep;
        }

        //EF Construtor
        protected Endereco() { }

        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Municipio { get; private set; }
        public string Estado { get; private set; }
        public string UF { get; private set; }
        public string CEP { get; private set; }
        public Guid? PessoaId { get; private set; }
        
        //EF Propriedade de Navegação
        public virtual Pessoa Pessoa { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarLogradouro();
            ValidarNumero();
            ValidarBairro();
            ValidarMunicipio();
            ValidarEstado();
            ValidarUF();
            ValidarCEP();
            ValidationResult = Validate(this);
        }

        private void ValidarLogradouro()
        {
            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("Preencha o logradouro");
        }

        private void ValidarNumero()
        {
            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("Preencha o numero.");
        }

        private void ValidarBairro()
        {
            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("Preencha o bairro.");
        }

        private void ValidarMunicipio()
        {
            RuleFor(c => c.Municipio)
                .NotEmpty().WithMessage("Preencha o município.");
        }

        private void ValidarEstado()
        {
            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("Preencha o estado.");
        }

        private void ValidarUF()
        {
            RuleFor(c => c.UF)
                .NotEmpty().WithMessage("Preencha a uf.");
        }

        private void ValidarCEP()
        {
            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage("Preencha o cep.");
        }
        #endregion
    }
}