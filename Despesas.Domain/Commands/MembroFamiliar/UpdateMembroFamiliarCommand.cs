using System;
using Despesas.Domain.Commands.Contracts;
using Despesas.Domain.Enums;
using Flunt.Notifications;
using Flunt.Validations;

namespace Despesas.Domain.Commands.MembroFamiliar
{
    public class UpdateMembroFamiliarCommand : Notifiable, ICommand
    {
        public UpdateMembroFamiliarCommand(Guid id,string nomeSocial, string sobrenome, DateTime dataNascimento, string email, string chaveDeAcesso)
        {
            Id = id;
            NomeSocial = nomeSocial;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Email = email;
            ChaveDeAcesso = chaveDeAcesso;
        }

        public Guid Id { get; set; }
        public string NomeSocial { get; set; }    
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string ChaveDeAcesso { get; set; }

        public void Validate()
        {
             AddNotifications(new Contract()
                .Requires()
                .IsNull(Id,"Id","O Id deve ser Enviado."));
        }
    }
}