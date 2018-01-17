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
        public IActionResult Register([FromBody] Account client)
        {
            // validate and talk to database
            return Ok(client);
        }

        // POST account/login
        [HttpPost]
        public IActionResult Login([FromBody] Account client)
        {
            // validate that the credentials are correct, return client
            return Ok(client);
        }

        // POST account/update
        [HttpPost]
        public IActionResult Update([FromBody] Account client)
        {
            // change values in library and database

            return Ok();
        }

    }
}