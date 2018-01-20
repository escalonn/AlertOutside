using LocationAlert.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LocationAlert.Data.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PreferencesController : Controller
    {
        public LocationAlertDBContext DBContext { get; set; }

        public PreferencesController(LocationAlertDBContext dbContext)
        {
            DBContext = dbContext;
        }

        // GET preferences/
        [HttpGet]
        public IActionResult Get()
        {
            // return preferences of all accounts to caller
            return Ok();
        }

        // GET preferences/undefined@gmail.com
        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            // return preferences of an account to caller
            // (for when a user is still logged in but the client doesn't know his prefs anymore)
            Client clientOut;
            try
            {
                clientOut = DBContext.Client.AsNoTracking().First(c => c.Email == email);
            }
            catch (InvalidOperationException)
            {
                // account with email does not exist
                return BadRequest();
            }
            return Ok(clientOut);
        }

        // PUT preferences/undefined@gmail.com
        [HttpPut("{email}")]
        public IActionResult Put(string email)
        {
            try
            {
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
