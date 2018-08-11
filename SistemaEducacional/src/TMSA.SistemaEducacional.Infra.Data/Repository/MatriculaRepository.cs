using System;
using System.Collections.Generic;
using TMSA.SistemaEducacional.Domain.Matriculas;
using TMSA.SistemaEducacional.Domain.Matriculas.Repository;
using TMSA.SistemaEducacional.Infra.Data.Context;

namespace TMSA.SistemaEducacional.Infra.Data.Repository
{
    public class MatriculaRepository : Repository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(SistemaEducacionalContext context) : base(context)
        {
        }

        public Matricula ObterMatriculaPorNomeDoAluno(string nomeDoAluno)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Matricula> ObterMatriculasPorAnoCadastrado(DateTime anoCadastrado)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Matricula> ObterMatriculasPorDataDeDesligamento(DateTime dataDeDesligamento)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Matricula> ObterMatriculasPorStatus(string status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Matricula> ObterMatriculasPorTurno(Turno turno)
        {
            throw new NotImplementedException();
        }
    }
}
