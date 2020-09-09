using Despesas.Domain.ValueObjects.Contracts;

namespace Despesas.Domain.ValueObjects
{
    public class Nome : ValueObject
    {
        public Nome(string nome, string sobrenome)
        {
            NomeSocial = nome;
            Sobrenome = sobrenome;
        }

        protected Nome(){}

        public string NomeSocial { get; private set; }    
        public string Sobrenome { get; private set; }
    

        public override string ToString(){
            return $"{NomeSocial} {Sobrenome}";
        }

        public void AtualizarNome(string nomeSocial, string sobrenome)
        {
            NomeSocial = nomeSocial;         
            Sobrenome = sobrenome;
        }
    }
}