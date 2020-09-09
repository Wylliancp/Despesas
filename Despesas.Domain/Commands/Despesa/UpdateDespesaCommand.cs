using System;
using Despesas.Domain.Commands.Contracts;
using Despesas.Domain.Enums;
using Flunt.Notifications;
using Flunt.Validations;

namespace Despesas.Domain.Commands.Despesa
{
    public class UpdateDespesaCommand : Notifiable, ICommand
    {
        public UpdateDespesaCommand(){ }

        public Guid Id {get; set;}
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public ETipoDespesa TipoDespesa { get;set; }

        public string ChaveDeAcesso { get; set; }

        public void Validate()
        {
             AddNotifications(new Contract()
                .Requires()
                .IsNull(Id,"Id","O Id deve ser Enviado.")
                .IsNullOrEmpty(Nome,"Nome","O nome deve ser preenchido.")
                .IsNullOrEmpty(Descricao,"Descricao","A Descricao deve ser preenchido.")
                .IsLowerOrEqualsThan(0,Valor,"Valor", "O valor não pode ser nulo"));
        }
    }
}