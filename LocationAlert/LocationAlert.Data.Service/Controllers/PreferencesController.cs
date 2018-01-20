using Microsoft.AspNetCore.Mvc;

namespace LocationAlert.Data.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PreferencesController : Controller
    {
        // GET preferences/
        [HttpGet]
        public IActionResult Get()
        {
            // return preferences of all accounts to caller
            return Ok();
        }

        // GET preferences/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // return preferences of an account to caller
            // (for when a user is still logged in but the client doesn't know his prefs anymore)
            return Ok();
        }
    }
}
