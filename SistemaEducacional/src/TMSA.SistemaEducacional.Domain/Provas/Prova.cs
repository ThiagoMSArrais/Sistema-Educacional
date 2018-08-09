using System;
using TMSA.SistemaEducacional.Domain.Alunos;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Matriculas;

namespace TMSA.SistemaEducacional.Domain.Provas
{
    public class Prova : Entity<Prova>
    {
        public Prova(
            Double? notaPrimeiroSemestre,
            Double? notaSegundoSemestre,
            Double? mediaDoPrimeiroESegundoSememestre,
            Double? notaFinal,
            StatusAprovacao statusAprovacao)
        {
            NotaPrimeiroSemestre = notaPrimeiroSemestre;
            NotaSegundoSemestre = notaSegundoSemestre;
            MediaDoPrimeiroESegundoSemestre = mediaDoPrimeiroESegundoSememestre;
            NotaFinal = notaFinal;
            StatusAprovacao = statusAprovacao;
        }

        //EF Construtor
        protected Prova() { }

        public Double? NotaPrimeiroSemestre { get; private set; }
        public Double? NotaSegundoSemestre { get; private set; }
        public Double? MediaDoPrimeiroESegundoSemestre { get; private set; }
        public Double? NotaFinal { get; private set; }
        public StatusAprovacao StatusAprovacao { get; private set; }
        public Guid? AlunoId { get; private set; }
        public Guid? DisciplinaId { get; private set; }


        //EF PROPRIEDADE DE NAVEGAÇÃO
        public virtual Aluno Aluno { get; private set; }
        public virtual Disciplina Disciplina { get; private set; }

        public override bool EhValido()
        {
            //Todo: 
            return true;
        }
    }
}