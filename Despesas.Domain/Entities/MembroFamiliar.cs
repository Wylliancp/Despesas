using System;
using Despesas.Domain.Entities.Contracts;
using Despesas.Domain.ValueObjects;

namespace Despesas.Domain.Entities
{
    public class MembroFamiliar : Entity
    {
        public MembroFamiliar(Nome nome, DateTime dataNascimento, Email email, string chaveDeAcesso)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
            ChaveDeAcesso = chaveDeAcesso;
        }

        protected MembroFamiliar(){}

        public Nome Nome { get; private set; }    
        public DateTime DataNascimento { get; private set; }
        public Email Email { get; private set; }
        public string ChaveDeAcesso { get; private set; }


        public void AtualizarMembroFamiliar(Nome nome, Email email, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
        }

    }
}