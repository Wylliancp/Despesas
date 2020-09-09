using System;
using System.Collections.Generic;
using Despesas.Domain.Commands.Contracts;
using Despesas.Domain.Commands.Despesa;
using Despesas.Domain.Entities;
using Despesas.Domain.Handlers;
using Despesas.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Despesas.API.Controllers
{
    [ApiController]
    [Route("v1/Despesas")]
    public class DespesaController : Controller
    {
        private readonly IDespesaRepository _repository;
        private readonly DespesasHandler _handler;
        public DespesaController(IDespesaRepository repository, DespesasHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }        

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Despesa> GetById( Guid id)
        {
            //var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _repository.GetById(id,"xpto123t");

            return  Ok(result);
        }

        [Route("all")]
        [HttpGet]
        public ActionResult<IEnumerable<Despesa>> GetAll()
        {
            //var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var chaveDeAcesso = "xpto123t";
            return  Ok(_repository.GetAll(chaveDeAcesso));
        }
    
        [Route("")]
        [HttpPost] 
        public ActionResult<GenericCommandResult> Create(
            [FromBody] CreateDespesaCommand command
        )
        {
         //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
         command.ChaveDeAcesso = "xpto123t";

         return Ok((GenericCommandResult)_handler.Handle(command));   
        }

        [Route("")]
        [HttpPut] 
        public ActionResult<GenericCommandResult> Update(
            [FromBody] UpdateDespesaCommand command
        )
        {
         //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
         command.ChaveDeAcesso = "xpto123t";

         return Ok((GenericCommandResult)_handler.Handle(command));   
        }

        [Route("")]
        [HttpDelete] 
        public ActionResult<GenericCommandResult> Delete(
            [FromBody] DeleteDespesaCommand command
        )
        {
         //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
         command.ChaveDeAcesso = "xpto123t";
         return Ok((GenericCommandResult)_handler.Handle(command));   
        }
        
    }
}