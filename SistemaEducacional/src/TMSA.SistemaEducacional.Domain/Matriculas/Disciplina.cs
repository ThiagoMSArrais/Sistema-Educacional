﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TMSA.SistemaEducacional.Domain.Alunos;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Presencas;
using TMSA.SistemaEducacional.Domain.Professores;
using TMSA.SistemaEducacional.Domain.Provas;

namespace TMSA.SistemaEducacional.Domain.Matriculas
{
    public class Disciplina : Entity<Disciplina>
    {
        public Disciplina(
            string nome,
            DiaDaSemana diaDaSemana,
            int turma)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DiaDaSemana = diaDaSemana;
            Turma = turma;
        }

        // EF Construtor
        protected Disciplina() { }

        public string Nome { get; private set; }
        public DiaDaSemana? DiaDaSemana { get; private set; }
        public int Turma { get; private set; }
        public Guid? PresencaId { get; private set; }
        public Guid? ProvaId { get; private set; }

        // EF Propriedades de Navegação
        public virtual ICollection<Aluno> Alunos { get; set; }
        [NotMapped]
        public virtual ICollection<Professor> Professores { get; set; }
        public virtual Presenca Presenca { get; private set; }
        public virtual Prova Prova { get; private set; }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações
        private void Validar()
        {
            ValidarNome();
            ValidarDiaDaSemana();
            ValidarTurma();
            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome da disciplina tem que ser preenchido.");
        }

        private void ValidarDiaDaSemana()
        {
            RuleFor(c => c.DiaDaSemana)
                .NotNull().WithMessage("Selecione o dia da semana.");
        }

        private void ValidarTurma()
        {
            RuleFor(c => c.Turma)
                .NotEmpty().WithMessage("Preenchar o número da turma.");
        }
        #endregion
    }
}