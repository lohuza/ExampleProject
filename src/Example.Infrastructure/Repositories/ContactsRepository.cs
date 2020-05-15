using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example.Domain.Interfaces;
using Example.Domain.Models;
using Example.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ExampleDbContext _context;

        public ContactsRepository(ExampleDbContext context)
        {
        }

        public IEnumerable<Contact> GetUserContacts(int userId)
        {
            return _context.Users.Where(u => u.Id == userId).FirstOrDefault()?.Contacts;
        }
    }
}
