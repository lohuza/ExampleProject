using System;
using System.Collections.Generic;
using Example.Domain.Models;

namespace Example.Domain.Interfaces
{
    public interface IContactsRepository
    {
        IEnumerable<Contact> GetUserContacts(int userId);
    }
}
