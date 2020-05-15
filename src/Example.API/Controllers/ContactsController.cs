using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Example.Domain.Interfaces;
using Example.Domain.Models;
using Example.Domain.Resources.Contacts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Example.API.Controllers
{
    [Route("api/{username}/[controller]")]
    public class ContactsController : JwtController
    {
        private readonly IContactsRepository _repository;
        private readonly IMapper _mapper;

        public ContactsController(IContactsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ContactResource> Get()
        {
            int userId = GetUserId();
            var contacts = _repository.GetUserContacts(userId);
            var userContacts = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactResource>> (contacts);

            return userContacts;
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
