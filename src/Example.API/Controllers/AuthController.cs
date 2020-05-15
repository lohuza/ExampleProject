using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Example.Domain.Interfaces;
using Example.Domain.Models;
using Example.Domain.Resources.Users;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Example.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IUsersRepository _repository;
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;
        private readonly IMapper _mapper;

        public AuthController(IUsersRepository repository, IJwtFactory jwtFactory, ITokenFactory tokenFactory, IMapper mapper)
        {
            _repository = repository;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginResource credentials)
        {
            // radgan mxolod ID mchirdeba mxolod magas davabrunebineb repos
            // realurad object unda dabrundes magram... 
            var user = await _repository.LoginAsync(credentials);

            if (user == null)
            {
                return Unauthorized();
            }

            // am nawilze vfiqrobdi xom ar gametana calketqo orive rogorc tokeni magram
            // me jwt token factory calke maqvs da sxva token factory calke
            var token = _jwtFactory.GenerateEncodedToken(user.Id);
            var refreshToken = _tokenFactory.GenerateToken();
            // TODO: Save refresh token in db for renew 

            // ubralod martivad davabruneb am shemtxvevashi tokens 
            return Ok(new { token, refreshToken });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterResource registerResource)
        {
            var user = _mapper.Map<UserRegisterResource, User>(registerResource);
            await _repository.RegisterAsync(user, registerResource.Password);
            var loginCredentials = _mapper.Map<UserRegisterResource, UserLoginResource>(registerResource);

            return RedirectToAction(nameof(Login), loginCredentials);
        }

        // TODO: add refresh token functionality
    }
}
