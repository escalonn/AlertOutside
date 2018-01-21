using LocationAlert.Data.Models;
using LocationAlert.Data.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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
        public IActionResult Register([FromBody] Account clientIn)
        {
            try
            {
                Client dbClient = DataHelper.ToDataModel(clientIn);
                // validate and create in database with default prefs
                // return account
                DBContext.Add(dbClient);
                try
                {
                    DBContext.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    // account with email already exists
                    return BadRequest();
                }
                Account clientOut = DataHelper.ToDataSvcModel(dbClient);
                return Ok(clientOut);
            }
            catch (Exception e)
            {
                BadRequest(e);
            }
        }
    }
}
