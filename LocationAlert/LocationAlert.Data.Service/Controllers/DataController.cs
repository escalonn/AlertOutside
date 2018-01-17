using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocationAlert.Data.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Data")]
    public class DataController : Controller
    {
        // POST data/register
        [HttpPost]
        public IActionResult Register()
        {
            // validate and talk to database
            return Ok();
        }

        // POST data/login
        [HttpPost]
        public IActionResult Login()
        {
            // validate and talk to database
            return Ok();
        }

        // POST data/update
        [HttpPost]
        public IActionResult Update()
        {
            // validate and talk to database
            return Ok();
        }
    }
}