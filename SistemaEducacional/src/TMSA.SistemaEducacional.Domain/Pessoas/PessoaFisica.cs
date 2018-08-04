using System;
using TMSA.SistemaEducacional.Domain.Core.Models;

namespace TMSA.SistemaEducacional.Domain.Pessoas
{
    public class PessoaFisica : Entity<PessoaFisica>
    {

        public DateTime DataDeNascimento { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public EstadoCivil EstadoCivil { get; private set; }
        public GrauEscolar GrauEscolar { get; private set; }
        public Guid PessoaId { get; private set; }

        // EF Propriedades Navegação
        public virtual Pessoa Pessoa { get; private set; }
        
        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
