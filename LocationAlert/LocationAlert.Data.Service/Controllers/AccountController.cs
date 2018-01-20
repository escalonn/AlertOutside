using LocationAlert.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocationAlert.Data.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        // POST account/register
        [HttpPost]
        public IActionResult Register([FromBody] Client client)
        {
            // validate and create in database with default prefs
            // return account
            return Ok();
        }

        // POST account/login
        [HttpPost]
        public IActionResult Login([FromBody] Client client)
        {
            // validate and retreive from database
            // return account
            return Ok();
        }
    }
}