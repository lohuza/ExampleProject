using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Example.Domain.Models;

namespace Example.Domain.Interfaces
{
    public interface IContactsRepository
    {
        Task AddContactAsync(Contact contact);
        IEnumerable<Contact> GetUserContacts(int userId);
    }
}
