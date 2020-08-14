using Data.Contexts;
using Data.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data.UnityOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext _context;

        public UnitOfWork(IDataContext context)
        {
            _context = context;
        }

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public void Rollback() => _context.Dispose();
    }
}