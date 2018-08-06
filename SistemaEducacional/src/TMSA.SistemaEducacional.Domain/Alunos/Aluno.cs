using System;
using System.Collections.Generic;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Matriculas;
using TMSA.SistemaEducacional.Domain.Pessoas;
using TMSA.SistemaEducacional.Domain.Presencas;

namespace TMSA.SistemaEducacional.Domain.Alunos
{
    public class Aluno : Entity<Aluno>
    {

        //EF Construtor
        protected Aluno() { }

        public Guid? MatriculaId { get; private set; }
        public Guid? FiliacaoId { get; private set; }
        public Guid? PresencaId { get; private set; }
        public Guid? PessoaFisicaId { get; private set; }

        //EF Propriedade de Navegação
        public virtual Matricula Matricula { get; private set; }
        public virtual Filiacao Filiacao { get; private set; }
        public virtual Presenca Presenca { get; private set; }
        public virtual PessoaFisica PessoaFisica { get; private set; }
        public virtual ICollection<Disciplina> Disciplinas { get; private set; }

        public override bool EhValido()
        {
            //TODO: SEM VALIDAÇÃO LOCAL.
            return true;
        }
    }
}