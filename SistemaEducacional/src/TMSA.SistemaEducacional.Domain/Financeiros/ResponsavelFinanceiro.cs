using System;
using System.Collections.Generic;
using TMSA.SistemaEducacional.Domain.Alunos;
using TMSA.SistemaEducacional.Domain.Core.Models;
using TMSA.SistemaEducacional.Domain.Pessoas;

namespace TMSA.SistemaEducacional.Domain.Financeiros
{
    public class ResponsavelFinanceiro : Entity<ResponsavelFinanceiro>
    {

        //EF Construtor
        protected ResponsavelFinanceiro() { ]}

        public Guid? DadosBancariosId{ get; private set; }
        public Guid? CartaoDeCreditoId { get; private set; }
        public Guid? PessoaJuridicaId { get; private set; }
        public Guid? PessoaFisicaId { get; private set; }

        //EF Propriedades de Navegação
        public virtual DadosBancario DadosBancario { get; private set; }
        public virtual CartaoDeCredito CartaoDeCredito { get; private set; }
        public virtual PessoaJuridica PessoaJuridica { get; private set; }
        public virtual PessoaFisica PessoaFisica { get; private set; }
        public virtual ICollection<Aluno> AlunosBeneficiados { get; private set; }

        public override bool EhValido()
        {
            //TODO: tratar as validações.
            return true;
        }
    }
}