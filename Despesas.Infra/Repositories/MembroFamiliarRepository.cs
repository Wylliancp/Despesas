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
    public class MembroFamiliarRepository : IMembroFamiliarRepository
    {

        private readonly DataContext _context;

        public MembroFamiliarRepository(DataContext context)
        {
            _context = context;
        }
        public MembroFamiliar CheckEmail(string email)
        {
            var result = _context.MembroFamiliars.Where(x => x.Email.Address == email).FirstOrDefault();
            return result;
        }

        public void Create(MembroFamiliar membro)
        {
            _context.MembroFamiliars.Add(membro);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var membro = _context.MembroFamiliars.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            _context.MembroFamiliars.Remove(membro);
            _context.SaveChanges();
        }

        public IEnumerable<MembroFamiliar> GetAll(string chaveDeAcesso)
        {
            return _context.MembroFamiliars.AsNoTracking().Where(MembroFamiliarQueries.GetAll(chaveDeAcesso));
        }

        public MembroFamiliar GetById(Guid id, string chaveDeAcesso)
        {
            return _context.MembroFamiliars.AsNoTracking()
                                           .Where(MembroFamiliarQueries.GetById(id,chaveDeAcesso))
                                           .FirstOrDefault();
        }

        public void Update(MembroFamiliar membro)
        {
            _context.Entry(membro).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}