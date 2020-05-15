using System;
using Example.Domain.Interfaces;
using Example.Infrastructure.Persistence;

namespace Example.Infrastructure.Repositories
{
    public class PhoneNumbersRepository : IPhoneNumbersRepository
    {
        private readonly ExampleDbContext _context;

        public PhoneNumbersRepository(ExampleDbContext context)
        {
        }
    }
}
