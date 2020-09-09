using System;
using Despesas.Domain.Commands.Contracts;
using Despesas.Domain.Enums;
using Flunt.Notifications;
using Flunt.Validations;

namespace Despesas.Domain.Commands.Despesa
{
    public class CreateDespesaCommand : Notifiable, ICommand
    {
        public CreateDespesaCommand(){ }

        public CreateDespesaCommand(string nome, string descricao, decimal valor, ETipoDespesa tipoDespesa, Guid idMembroFamiliar, EFormaPagamento formaPagamento, bool pago, DateTime dataPagamento, string chaveDeAcesso)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            TipoDespesa = tipoDespesa;
            IdMembroFamiliar = idMembroFamiliar;
            FormaPagamento = formaPagamento;
            Pago = pago;
            DataPagamento = dataPagamento;
            ChaveDeAcesso = chaveDeAcesso;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public ETipoDespesa TipoDespesa { get; set; }
        public Guid IdMembroFamiliar {get ;set;}
        public EFormaPagamento FormaPagamento { get; set; }
        public bool Pago { get; set; }
        public DateTime DataPagamento { get; set; }

        public string ChaveDeAcesso { get; set; }

        public void Validate()
        {
             AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome,"Nome","O nome deve ser preenchido.")
                .IsNotNullOrEmpty(Descricao,"Descricao","A Descricao deve ser preenchido.")
                .IsLowerOrEqualsThan(0,Valor,"Valor", "O valor não pode ser nulo"));
        }
    }
}