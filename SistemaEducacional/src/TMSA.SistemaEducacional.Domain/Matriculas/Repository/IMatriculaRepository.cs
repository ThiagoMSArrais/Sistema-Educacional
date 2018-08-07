using System;
using System.Collections.Generic;
using TMSA.SistemaEducacional.Domain.Interfaces;

namespace TMSA.SistemaEducacional.Domain.Matriculas.Repository
{
    public interface IMatriculaRepository : IRepository<Matricula>
    {
        IEnumerable<Matricula> ObterMatriculasPorStatus(string status);
        IEnumerable<Matricula> ObterMatriculasPorAnoCadastrado(DateTime anoCadastrado);
        IEnumerable<Matricula> ObterMatriculasPorDataDeDesligamento(DateTime dataDeDesligamento);
        IEnumerable<Matricula> ObterMatriculasPorTurno(Turno turno);
        Matricula ObterMatriculaPorNomeDoAluno(string nomeDoAluno);
    }
}