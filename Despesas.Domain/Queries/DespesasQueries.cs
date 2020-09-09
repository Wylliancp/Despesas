using System;
using System.Linq.Expressions;
using Despesas.Domain.Entities;

namespace Despesas.Domain.Queries
{
    public static class DespesasQueries
    {
        public static Expression<Func<Despesa,bool>> GetById(Guid id, string chaveDeAcesso)
        {
            return x => x.Id == id && x.MembroFamiliar.ChaveDeAcesso == chaveDeAcesso;
        }

        public static Expression<Func<Despesa,bool>> GetAll(string chaveDeAcesso)
        {
            return x => x.MembroFamiliar.ChaveDeAcesso == chaveDeAcesso;
        }
    }
}