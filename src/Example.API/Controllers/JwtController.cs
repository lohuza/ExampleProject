using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Controllers
{
    [Route("api/[controller]")]
    public class JwtController : Controller
    {
        public JwtController()
        {

        }

        protected int GetUserId()
        {
            var userId = User.FindFirst("userId");
            if (int.TryParse(userId.Value, out int result))
            {
                return result;
            }
            else
            {
                throw new Exception("couldn't get user id");
            }
        }
    }
}
