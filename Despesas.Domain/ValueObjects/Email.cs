using Despesas.Domain.ValueObjects.Contracts;

namespace Despesas.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
        }
        
        protected Email(){}

        public string Address { get; private set; }

        public void AtualizarEnderecoEmail(string address)
        {
            Address = address;
        }
    }
}