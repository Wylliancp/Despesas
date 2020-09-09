using System;
using System.Linq.Expressions;
using Despesas.Domain.Entities;

namespace Despesas.Domain.Queries
{
    public static class MembroFamiliarQueries
    {

        public static Expression<Func<MembroFamiliar, bool>> GetById(Guid id, string chaveDeAcesso)
        {
            return x => x.Id == id && x.ChaveDeAcesso == chaveDeAcesso;
        }

        public static Expression<Func<MembroFamiliar, bool>> GetAll(string chaveDeAcesso)
        {
            return x => x.ChaveDeAcesso == chaveDeAcesso;
        }
        
    }
}