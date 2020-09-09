using Despesas.Domain.Commands.Despesa;
using Despesas.Domain.Commands.Contracts;
using Despesas.Domain.Entities;
using Despesas.Domain.Handlers.Contracts;
using Despesas.Domain.IRepositories;
using Flunt.Notifications;

namespace Despesas.Domain.Handlers
{
    public class DespesasHandler : Notifiable, 
    IHandler<CreateDespesaCommand>,
    IHandler<UpdateDespesaCommand>,
    IHandler<DeleteDespesaCommand>
    {

        private readonly IDespesaRepository _repository;
        private readonly IMembroFamiliarRepository _membroRepository;

        public DespesasHandler(IDespesaRepository repository, IMembroFamiliarRepository membroRepository)
        {
            _repository = repository;
            _membroRepository = membroRepository;
        }

        public ICommandResult Handle(CreateDespesaCommand command)
        {
            command.Validate();

            if(command.Invalid)
                 return new GenericCommandResult(false,"Ops, Alguma inconsistencia nos dados",command.Notifications);

            
            //Gerar Entidades
            var membrofamiliar = _membroRepository.GetById(command.IdMembroFamiliar, command.ChaveDeAcesso);
            
            if(membrofamiliar == null)
            {
                command.AddNotification("MembroFamiliar", "Membro Familiar Inexistente");
                return new GenericCommandResult(false,"Ops, Alguma inconsistencia nos dados",command.Notifications);
            }

            var pagamento = new Pagamento(command.FormaPagamento,command.Valor,command.Pago); 
            var despesa = new Despesa(command.Nome,command.Descricao,command.Valor,pagamento,command.TipoDespesa,membrofamiliar);
            
            //Salva no banco de dados
            _repository.Create(despesa);

            return new GenericCommandResult(true,"Despesa Criada com Sucesso!",despesa);
        }

        public ICommandResult Handle(UpdateDespesaCommand command)
        {
            //Fail Fast Validations
            command.Validate();

            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, Alguma inconsistencia nos dados", command.Notifications);
            

            //ReHidratação
            var despesa = _repository.GetById(command.Id, command.ChaveDeAcesso);

            //alterar despesa
            despesa.AtualizarDespesa(command.Nome,command.Descricao,command.Valor, command.TipoDespesa);

            //Atualiza no banco
            _repository.Update(despesa);

            return new GenericCommandResult(true, "Despesa Criado com Sucesso!", despesa);
        }

        public ICommandResult Handle(DeleteDespesaCommand command)
        {
            command.Validate();

            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, Alguma inconsistencia nos dados", command.Notifications);
            
            var despesa = _repository.GetById(command.Id, command.ChaveDeAcesso);

            _repository.Delete(despesa.Id);

            return new GenericCommandResult(true, $"A despesa {despesa.Nome.ToString()} foi excluida com Sucesso!", despesa);
        }
    }
}