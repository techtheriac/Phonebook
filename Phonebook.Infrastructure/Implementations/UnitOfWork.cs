using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Domain.Models;
using Phonebook.Infrastructure.Abstractions;

namespace Phonebook.Infrastructure.Implementations
{
    class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        private IGenericRepository<Contact> _contacts;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Contact> Contacts => 
            _contacts ??= new GenericRepository<Contact>(_context); 
        
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose(); 
            GC.SuppressFinalize(this);
        }
    }
}
