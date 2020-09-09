using System;
using System.Collections.Generic;
using Despesas.Domain.Entities;

namespace Despesas.Domain.IRepositories
{
    public interface IMembroFamiliarRepository
    {
         void Create(MembroFamiliar membro);
         void Update(MembroFamiliar membro);
         void Delete(Guid id);

         MembroFamiliar CheckEmail(string email);
         MembroFamiliar GetById(Guid id, string chaveDeAcesso);
         IEnumerable<MembroFamiliar> GetAll(string chaveDeAcesso);
        
    }
}