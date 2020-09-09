using System;
using Despesas.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Despesas.Domain.Commands.MembroFamiliar
{
    public class DeleteMembroFamiliarCommand : Notifiable, ICommand
    {
        public DeleteMembroFamiliarCommand(){ }

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