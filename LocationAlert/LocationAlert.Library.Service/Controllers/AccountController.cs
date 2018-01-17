using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationAlert.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocationAlert.Library.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        // POST account/register
        [HttpPost]
        public void Register([FromBody] Account client)
        {

        }

        // POST account/login
        [HttpPost]
        public void Login([FromBody] Account client)
        {

        }

        // POST account/update
        [HttpPost]
        public void Update([FromBody] Account client)
        {

        }

    }
}