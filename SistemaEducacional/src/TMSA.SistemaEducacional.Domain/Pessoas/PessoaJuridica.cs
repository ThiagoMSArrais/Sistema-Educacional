using System;
using TMSA.SistemaEducacional.Domain.Core.Models;

namespace TMSA.SistemaEducacional.Domain.Pessoas
{
    public class PessoaJuridica : Entity<PessoaJuridica>
    {
        public string CNPJ { get; private set; }
        public string InscricaoEstadutal { get; private set; }
        public string NomeFantasia { get; private set; }
        public string RazaoSocial { get; private set; }
        public Guid PessoaId { get; private set; }

        // EF Propriedade de Navegação
        public virtual Pessoa Pessoa { get; private set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
