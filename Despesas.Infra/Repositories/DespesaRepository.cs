using System;
using System.Collections.Generic;
using System.Linq;
using Despesas.Domain.Entities;
using Despesas.Domain.IRepositories;
using Despesas.Domain.Queries;
using Despesas.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Despesas.Infra.Repositories
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly DataContext _context;
        public DespesaRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Despesa todo)
        {
            //Como os dados dos Membro familiar e inserida antes e apenas consumida.
            //foi adicionado o seguinte treicho para que o EFCore não tente inserir 
            //o membro novamente e acarretar em Constraint
            _context.Entry(todo.MembroFamiliar).State = EntityState.Unchanged;
            
            _context.Despesas.Add(todo);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var despesa = _context.Despesas.AsNoTracking()
                                           .Where(x => x.Id == id)
                                           .FirstOrDefault();
            _context.Despesas.Remove(despesa);
            _context.SaveChanges();
        }

        public IEnumerable<Despesa> GetAll(string chaveDeAcesso)
        {
            return _context.Despesas.AsNoTracking()
                                    .Where(DespesasQueries.GetAll(chaveDeAcesso))
                                    .Include(x => x.MembroFamiliar);
        }

        public Despesa GetById(Guid id, string chaveDeAcesso)
        {
            return _context.Despesas.AsNoTracking()
                                    .Where(DespesasQueries.GetById(id, chaveDeAcesso))
                                    .Include(x => x.MembroFamiliar)
                                    .FirstOrDefault();
        }

        public void Update(Despesa despesa)
        {
            _context.Entry(despesa).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}