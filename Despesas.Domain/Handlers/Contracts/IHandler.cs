using Despesas.Domain.Commands.Contracts;

namespace Despesas.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }


}