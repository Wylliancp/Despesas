using System;
using Despesas.Domain.Entities.Contracts;
using Despesas.Domain.Enums;

namespace Despesas.Domain.Entities
{
    public class Pagamento : Entity
    {
        public Pagamento(EFormaPagamento formaPagamento, decimal valor, bool pago) 
        {
                FormaPagamento = formaPagamento;
                Valor = valor;
                Pago = pago;
                DataPagamento = DateTime.Now;      
        }

        protected Pagamento(){}
        
        public EFormaPagamento FormaPagamento { get; private set; }
        public decimal Valor { get; private set; }
        public bool Pago { get; private set; }
        public DateTime DataPagamento { get; private set; }
    }
}