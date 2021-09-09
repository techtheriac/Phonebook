using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.Domain.Models;

namespace Phonebook.Infrastructure.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Contact> Contacts { get; }
        Task Save();
    }
}
