using System.Collections.Generic;
using TMSA.SistemaEducacional.Domain.Interfaces;

namespace TMSA.SistemaEducacional.Domain.Matriculas.Repository
{
    public interface IMatriculaRepository : IRepository<Matricula>
    {
        IEnumerable<Matricula> ObterMatriculasPorStatus(string status);
        IEnumerable<Matricula> ObterMatriculasPorAnoCadastrado(int anoCadastrado);
        Matricula ObterMatriculaPorNomeDoAluno(string nomeDoAluno);
    }
}