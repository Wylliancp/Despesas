using System;
using Despesas.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace Despesas.Domain.Commands.MembroFamiliar
{
    public class CreateMembroFamiliarCommand : Notifiable, ICommand
    {
        public CreateMembroFamiliarCommand(){ }

        public CreateMembroFamiliarCommand(string nomeSocial, string sobrenome, DateTime dataNascimento, string email, string chaveDeAcesso)
        {
            NomeSocial = nomeSocial;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Email = email;
            ChaveDeAcesso = chaveDeAcesso;
        }

        public string NomeSocial { get; set; }    
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string ChaveDeAcesso { get; set; }

        public void Validate()
        {
             AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(NomeSocial, "Nome Social", "Nome Social Obrigatorio")
                .IsNotNullOrEmpty(Sobrenome, "Sobrenome", "Sobrenome Obrigatorio")
                .IsEmailOrEmpty(Email, "E-mail", "E-mail Obrigatorio")
                .IsNullOrNullable(DataNascimento, "DataNascimento", "Data de Nascimento Obrigatoria"));
        }
    }
}