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
using Newtonsoft.Json;
using System.Text;

namespace LocationAlert.Library.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private static HttpClient s_httpClient = new HttpClient();

        public static string DataUrl { get; set; }

        //for sending account from library service to library
        //public static List<Account> _account = new List<Account>();

        // POST account/register
        [HttpPost]
        public IActionResult Register([FromBody] Account clientIn)
        {
            // validate and talk to database
            string jsonOut = JsonConvert.SerializeObject(clientIn);
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, DataUrl + "/api/account/register")
            {
                Content = new StringContent(jsonOut, Encoding.UTF8, "application/json")
            };

            HttpResponseMessage res = s_httpClient.SendAsync(req).GetAwaiter().GetResult();
            if (!res.IsSuccessStatusCode)
            {
                return BadRequest(res);
            }

            string jsonIn = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Account clientOut = JsonConvert.DeserializeObject<Account>(jsonIn);

            return Ok(clientOut);
        }

        // Get account/login account purpose -------------------------------------------------------------------
        [HttpPost]
        public IActionResult Login([FromBody] Account client)
        {
            // TODO verify user

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, client.Email)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity)
            ).GetAwaiter().GetResult();

            // validate and talk to database
            //string jsonOut = JsonConvert.SerializeObject(client);
            //HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, DataUrl + "/api/account/login")
            //{
            //    Content = new StringContent(jsonOut, Encoding.UTF8, "application/json")
            //};

            //HttpResponseMessage res = s_httpClient.SendAsync(req).GetAwaiter().GetResult();
            //if (!res.IsSuccessStatusCode)
            //{
            //    return BadRequest(res);
            //}

            //string jsonIn = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            //Account clientOut = JsonConvert.DeserializeObject<Account>(jsonIn);

            //return Ok(clientOut);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).GetAwaiter().GetResult();
            return Ok();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------

        // POST account/update
        [Authorize]
        [HttpPost]
        public IActionResult Update([FromBody] Account clientIn)
        {
            // if trying to update a different user...
            if (HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value != clientIn.Email)
            {
                // not authorized to do that
                return StatusCode(403);
            }
            else
            {
                // otherwise, change values in database
                string jsonOut = JsonConvert.SerializeObject(clientIn);
                HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, DataUrl + "/api/account/update")
                {
                    Content = new StringContent(jsonOut, Encoding.UTF8, "application/json")
                };

                //Change values in library
                var updateClient = ServerTicker.AccountList.FirstOrDefault(a => a.Email.Equals(clientIn.Email));
                    if (updateClient == null)
                    {
                        return StatusCode(400);
                    }
                    else
                    {
                        updateClient = clientIn;
                        return Ok();
                    }
                   
            }

        }
            

    }
}
