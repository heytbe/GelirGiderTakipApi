using Data.API.Context;
using Data.API.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API.UnitOfWork.Concrate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public int Save()
        {
           return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
