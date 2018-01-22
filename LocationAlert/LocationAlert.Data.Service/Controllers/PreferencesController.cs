using LocationAlert.Data.Models;
using LocationAlert.Data.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        // GET api/preferences
        [HttpGet]
        public IActionResult Get()
        {
            // return preferences of all accounts to caller
            IEnumerable<Account> allAccounts = DBContext.Client
                .Include(c => c.Region)
                .Include(c => c.Preference)
                    .ThenInclude(p => p.WeatherPreference)
                .Select(DataHelper.ToDataSvcModel);

            return Ok(allAccounts);
        }

        // GET api/preferences/undefined@gmail.com
        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            // return preferences of an account to caller
            // (for when a user is still logged in but the client doesn't know his prefs anymore)
            Client dbClient;
            try
            {
                dbClient = DBContext.Client
                    .Include(c => c.Region)
                    .Include(c => c.Preference)
                        .ThenInclude(p => p.WeatherPreference)
                    .First(c => c.Email == email);
            }
            catch (InvalidOperationException)
            {
                // account with email does not exist
                return BadRequest();
            }
            Account client = DataHelper.ToDataSvcModel(dbClient);
            return Ok(client);
        }

        // PUT api/preferences/undefined@gmail.com
        [HttpPut("{email}")]
        public IActionResult Put(string email, [FromBody] Account client)
        {
            client.Email = email;
            Client dbClientUpdated = DataHelper.ToDataModel(client);
            try
            {
                Client dbClientExisting = DBContext.Client
                    .Include(c => c.Region)
                    .Include(c => c.Preference)
                        .ThenInclude(p => p.WeatherPreference)
                    .AsNoTracking()
                    .First(c => c.Email == client.Email);

                dbClientUpdated.ClientId = dbClientExisting.ClientId;
                dbClientUpdated.Preference.PreferenceId = dbClientExisting.PreferenceId;
                dbClientUpdated.Preference.WeatherPreference.WeatherPreferenceId = dbClientExisting.Preference.WeatherPreferenceId;
                // can't tell first region from second or third, to wire up the IDs, so just make new ones every time.

                DBContext.Update(dbClientUpdated);
            }
            catch (InvalidOperationException)
            {
                // there is no existing client with this email
                DBContext.Add(dbClientUpdated);
            }

            DBContext.SaveChanges();

            return Ok();
        }
    }
}
