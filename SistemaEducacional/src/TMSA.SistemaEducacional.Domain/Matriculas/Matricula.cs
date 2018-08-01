using System;
using TMSA.SistemaEducacional.Domain.Alunos;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Financeiros;

namespace TMSA.SistemaEducacional.Domain.Matriculas
{
    public class Matricula : Entity<Matricula>
    {

        public Matricula(
            DateTime dataCadastro,
            Turno turno)
        {
                
        }

        public DateTime DataCadastro { get; private set; }
        public StatusMatricula StatusMatricula { get; private set; }
        public Turno Turno { get; private set; }
        public Guid? FinanceiroId { get; private set; }
        public Guid? AlunoId { get; private set; }

        // EF Propriedades de Navegação
        public virtual Financeiro Financeiro { get; private set; }
        public virtual Aluno Aluno { get; set; }

        public override bool EhValido()
        {
            throw new System.NotImplementedException();
        }
    }
}