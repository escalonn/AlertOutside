using LocationAlert.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LocationAlert.Data.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        public LocationAlertDBContext DBContext { get; set; }

        public AccountController(LocationAlertDBContext dbContext)
        {
            DBContext = dbContext;
        }

        // POST account/register
        [HttpPost]
        public IActionResult Register([FromBody] Client client)
        {
            // validate and create in database with default prefs
            // return account
            DBContext.Add(client);
            try
            {
                DBContext.SaveChanges();
            }
            catch (DbUpdateException)
            {
                // account with email already exists
                return BadRequest();
            }
            return Ok(client);
        }
    }
}