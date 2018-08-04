using System;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Enderecos;

namespace TMSA.SistemaEducacional.Domain.Pessoas
{
    public class Pessoa : Entity<Pessoa>
    {

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
            throw new NotImplementedException();
        }
    }
}