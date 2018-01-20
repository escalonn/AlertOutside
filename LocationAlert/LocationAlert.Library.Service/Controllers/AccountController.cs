using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationAlert.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace LocationAlert.Library.Service.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        public static string DataUrl { get; set; }

        //for sending account from library service to library
        public static List<Account> _account = new List<Account>();



        // POST account/register
        [HttpPost]
        public IActionResult Register([FromBody] Account client)
        {
            // validate and talk to database
            return Ok(client);
        }

        // Get account/login  account purpose -------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> Login([FromBody] Account client)
        {
            var req = Request.HttpContext;

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Email, client.Email)
           };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await req.SignInAsync("EmailCookie", new ClaimsPrincipal(identity), new AuthenticationProperties()
            {
                IsPersistent = true,
                // ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddHours(1))
            });

            return Ok(client);


        }

        [HttpGet]
        public IActionResult Logout()
        {
            return Ok(HttpContext.SignOutAsync("EmailCookie"));
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------

        // POST account/update
        [HttpPost]
        public IActionResult Update([FromBody] Account client)
        {
            // change values in library and database

            return Ok();
        }

    }
}