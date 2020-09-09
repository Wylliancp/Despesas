using System;
using System.Collections.Generic;
using Despesas.Domain.Commands.Contracts;
using Despesas.Domain.Commands.MembroFamiliar;
using Despesas.Domain.Entities;
using Despesas.Domain.Handlers;
using Despesas.Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Despesas.API.Controllers
{
    [ApiController]
    [Route("v1/MembroFamiliar")]
    public class MembroFamiliarController : Controller
    {
        private readonly IMembroFamiliarRepository _repository;
        private readonly MembroFamiliarHandler _handler;
        public MembroFamiliarController(IMembroFamiliarRepository repository, MembroFamiliarHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }        

        [Route("{Guid:int}")]
        [HttpGet]
        public ActionResult<MembroFamiliar> GetById(Guid id)
        {
            //var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var result = _repository.GetById(id,"xpto123t");

            return  Ok(result);
        }

        [Route("all")]
        [HttpGet]
        public ActionResult<IEnumerable<MembroFamiliar>> GetAll()
        {
            //var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            var chaveDeAcesso = "xpto123t";
            return  Ok(_repository.GetAll(chaveDeAcesso));
        }
    
        [Route("")]
        [HttpPost] 
        public ActionResult<GenericCommandResult> Create(
            [FromBody] CreateMembroFamiliarCommand command
        )
        {
         //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
         command.ChaveDeAcesso = "xpto123t";

         return Ok((GenericCommandResult)_handler.Handle(command));   
        }

        [Route("")]
        [HttpPut] 
        public ActionResult<GenericCommandResult> Update(
            [FromBody] UpdateMembroFamiliarCommand command
        )
        {
         //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
         command.ChaveDeAcesso = "xpto123t";
        
         return Ok((GenericCommandResult)_handler.Handle(command));   
        }

        [Route("")]
        [HttpDelete] 
        public ActionResult<GenericCommandResult> Delete(
            [FromBody] DeleteMembroFamiliarCommand command
        )
        {
         //command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
         command.ChaveDeAcesso = "xpto123t";

         return Ok((GenericCommandResult)_handler.Handle(command));   
        }
        
    }
}