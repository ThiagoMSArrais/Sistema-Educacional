using FluentValidation;
using System;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Enderecos;

namespace TMSA.SistemaEducacional.Domain.Pessoas
{
    public class Pessoa : Entity<Pessoa>
    {
        public Pessoa(
            string nome,
            string email,
            string ddd,
            string telefone,
            string celular)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            DDD = ddd;
            Telefone = telefone;
            Celular = celular;
        }

        // EF Construtor
        protected Pessoa() { }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string DDD { get; private set; }
        public string Telefone { get; private set; }
        public string Celular { get; private set; }
        public Guid? EnderecoId { get; private set; }

        // EF Propriedades de Navegação
        public virtual Endereco Endereco { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarNome();
            ValidarEmail();
            ValidarDDD();
            ValidarTelefone();
            ValidarCelular();
            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Preencha o nome.");
        }

        private void ValidarEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Preencha o e-mail.");
        }

        private void ValidarDDD()
        {
            RuleFor(c => c.DDD)
                .NotEmpty().WithMessage("Preencha o DDD.");
        }

        private void ValidarTelefone()
        {
            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Preencha o telefone.");
        }

        private void ValidarCelular()
        {
            RuleFor(c => c.Celular)
                .NotEmpty().WithMessage("Preencha o celular.");
        }
        #endregion
    }
}