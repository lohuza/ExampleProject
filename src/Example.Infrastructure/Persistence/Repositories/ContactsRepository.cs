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
            _context = context;
        }

        public IEnumerable<Contact> GetContacts(int userId)
        {
            return _context.Users.Include(u => u.Contacts)
                .FirstOrDefault(u => u.Id == userId)?.Contacts;
        }

        public async Task<Contact> GetContactAsync(int contactId)
        {
    //        var user = await _context.Users.Include(u => u.Contacts)
    //.FirstOrDefaultAsync(u => u.Id == userId && u.Contacts.Any(c => c.Id == contactId));

    //        return user?.Contacts.FirstOrDefault();

            //var item = await _context.Users.Include(u => u.Contacts)
            //    .Where(u => u.Id == userId && u.Contacts.Any(c => c.Id == contactId))
            //    .Select(i => i.Contacts.FirstOrDefault())
            //    .FirstOrDefaultAsync();

            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == contactId);

            return contact;
        }

        public async Task AddContactAsync(Contact contact, int userId)
        {
            contact.UserId = userId;
            await _context.Contacts.AddAsync(contact);
        }

        public void DeleteContact(Contact contact)
        {
            _context.Contacts.Remove(contact);
        }
    }
}
