using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationAlert.Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;

namespace LocationAlert.Library.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private static HttpClient s_httpClient = new HttpClient();

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

        // Get account/login account purpose -------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> Login([FromBody] Account client)
        {
            // TODO verify user

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, client.Email)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties()
                {
                    IsPersistent = true,
                    // ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddHours(1))
                }
            );

            return Ok(client);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Logout()
        {
            return Ok(HttpContext.SignOutAsync("EmailCookie"));
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        // POST account/update
        [Authorize]
        [HttpPost]
        public IActionResult Update([FromBody] Account client)
        {
            // if trying to update a different user...
            if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value != client.Email)
            {
                // not authorized to do that
                return StatusCode(403);
            }
            // otherwise, change values in library and database
            // TODO

            return Ok();
        }

    }
}
