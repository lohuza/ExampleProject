using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Example.Domain.Interfaces;
using Example.Domain.Models;
using Example.Domain.Resources.Contacts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Controllers
{
    [Authorize]
    [Route("api/{username}/[controller]")]
    public class ContactsController : JwtController
    {
        private readonly IContactsRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactsController(IContactsRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
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
        public async Task<IActionResult> Post([FromBody]AddContactResource contactResource)
        {
            var contact = _mapper.Map<AddContactResource, Contact>(contactResource);
            await _repository.AddContactAsync(contact);

            // simartivistvis ubralod ok davabruneb
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
