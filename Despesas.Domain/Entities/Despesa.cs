using System;
using Despesas.Domain.Enums;
using Despesas.Domain.Entities.Contracts;
using Despesas.Domain.ValueObjects;

namespace Despesas.Domain.Entities
{
    public class Despesa : Entity
    {        
        public Despesa(string nome, string descricao, decimal valor, Pagamento pagamento, ETipoDespesa tipoDepesa, MembroFamiliar membroFamiliar) 
        {
                Nome = nome;
                Descricao = descricao;
                Valor = valor;
                DataCriacao = DateTime.Now;
                Pagamento = pagamento;
                TipoDepesa = tipoDepesa;
                MembroFamiliar = membroFamiliar;
        }

        protected Despesa(){}

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public Pagamento Pagamento { get; private set; }
        public ETipoDespesa TipoDepesa { get; private set; }
        public MembroFamiliar MembroFamiliar { get; private set; }

        public void AtualizarDespesa(string nome, string descricao, decimal valor, ETipoDespesa tipoDespesa)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            TipoDepesa = tipoDespesa;
        }
    }
}