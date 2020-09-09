using System;
using System.Collections.Generic;
using Despesas.Domain.Entities;

namespace Despesas.Domain.IRepositories
{
    public interface IDespesaRepository
    {
         void Create(Despesa todo);
         void Update(Despesa todo);
         void Delete(Guid id);

         Despesa GetById(Guid id, string chaveDeAcesso);
         IEnumerable<Despesa> GetAll(string chaveDeAcesso);

    }
}