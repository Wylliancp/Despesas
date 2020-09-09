using Despesas.Domain.Commands.Contracts;
using Despesas.Domain.Entities;
using Despesas.Domain.Handlers.Contracts;
using Despesas.Domain.IRepositories;
using Flunt.Notifications;
using Despesas.Domain.Commands.MembroFamiliar;
using Despesas.Domain.ValueObjects;

namespace Despesas.Domain.Handlers
{
    public class MembroFamiliarHandler : Notifiable, 
    IHandler<CreateMembroFamiliarCommand>,
    IHandler<UpdateMembroFamiliarCommand>,
    IHandler<DeleteMembroFamiliarCommand>
    {
        private readonly IMembroFamiliarRepository _membroRepository;

        public MembroFamiliarHandler(IMembroFamiliarRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }

        public ICommandResult Handle(CreateMembroFamiliarCommand command)
        {
            command.Validate();

            if(command.Invalid)
                 return new GenericCommandResult(false,"Ops, Alguma inconsistencia nos dados",command.Notifications);

            //  //Verifica se E-mail já esta cadastrado
            var result = _membroRepository.CheckEmail(command.Email);
            if(result != null)
            {
                command.AddNotification("Email", "Este E-mail já esta em uso");
                 return new GenericCommandResult(false,"Ops, Alguma inconsistencia nos dados",command.Notifications);
            }
            

            //Gerar os VOS

            var nome = new Nome(command.NomeSocial, command.Sobrenome);
            var email = new Email(command.Email);

            //Gerar Entidades
            var membrofamiliar = new MembroFamiliar(nome, command.DataNascimento, email, command.ChaveDeAcesso);
            
            
            //Salva no banco de dados
            _membroRepository.Create(membrofamiliar);

            return new GenericCommandResult(true,"Membro familiar Criada com Sucesso!",membrofamiliar);
        }

        public ICommandResult Handle(UpdateMembroFamiliarCommand command)
        {
            //Fail Fast Validations
            command.Validate();

            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, Alguma inconsistencia nos dados", command.Notifications);
            

            //ReHidratação
            var membro = _membroRepository.GetById(command.Id, command.ChaveDeAcesso);

            //Gerar os VOS
            var nome = new Nome(command.NomeSocial, command.Sobrenome);
            var email = new Email(command.Email);

            //alterar despesa
            membro.AtualizarMembroFamiliar(nome,email,command.DataNascimento);

            //Atualiza no banco
            _membroRepository.Update(membro);

            return new GenericCommandResult(true, "Membro Criado com Sucesso!", membro);
        }

        public ICommandResult Handle(DeleteMembroFamiliarCommand command)
        {
            command.Validate();

            if(command.Invalid)
                return new GenericCommandResult(false, "Ops, Alguma inconsistencia nos dados", command.Notifications);
            
            var membro = _membroRepository.GetById(command.Id, command.ChaveDeAcesso);

            _membroRepository.Delete(membro.Id);

            return new GenericCommandResult(true, $"O membro {membro.Nome.ToString()} foi excluida com Sucesso!", membro);
        }
    }
}