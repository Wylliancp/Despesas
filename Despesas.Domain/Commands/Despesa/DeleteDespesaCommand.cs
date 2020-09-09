using System;
using Despesas.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Despesas.Domain.Commands.Despesa
{
    public class DeleteDespesaCommand : Notifiable, ICommand
    {
        public DeleteDespesaCommand(){ }

        public Guid Id { get; set; }
        public string ChaveDeAcesso { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Id,"Id","O Id esta em branco."));
        }
    }
}