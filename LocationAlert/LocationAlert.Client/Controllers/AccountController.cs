using LocationAlert.Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LocationAlert.Client.ViewModels;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LocationAlert.Client.Controllers
{
    public class AccountController : Controller
    {
        private static SuperModel _SM = new SuperModel();
        private static HttpClient RestClient = new HttpClient();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Regions()
        {
            Account client = HttpContext.Session.Get<Account>("AccountKey");

            if (client == null)
            {
                client = new Account();
                HttpContext.Session.Set<Account>("AccountKey", client);
            }

            return View(client);
        }

        //public IActionResult EditRegion(string id, string lat, string lng, string radius)
        //{

        //    Region r = new Region(id, lat, lng, radius);

        //    Account client = HttpContext.Session.Get<Account>("AccountKey");

        //    if (r.ID <= client.RegionList.Count)
        //        {
        //            client.RegionList[r.ID] = r;
        //        }
        //    else
        //        {
        //            client.RegionList.Add(r);
        //             Console.WriteLine(client.RegionList.Count);
        //        }


        //    // Check the count
        //    // client.RegionList.Count(x => x != null);
        //    return View("Index");
        //}

        public IActionResult EditRegion(string[] latData, string[] lngData, string[] radiusData)
        {
            // Get current account
            Account client = HttpContext.Session.Get<Account>("AccountKey");

            // IDs are zero indexed!!
            for (int i = 0; i <= latData.Length - 1; i++)
            {
                Region r = new Region(i, latData[i], lngData[i], radiusData[i]);

                // Add Region
                if (r.ID >= client.RegionList.Count)
                {
                    client.RegionList.Add(r);
                }
                // Replace Region
                else
                {
                    client.RegionList[r.ID] = r;
                }
            }

            // Need to 'save' current account object
            HttpContext.Session.Set<Account>("AccountKey", client);

            return View("Regions", client);
        }

        public IActionResult Preferences()
        {
            return View();
        }

        public IActionResult WeatherPreference()
        {
            Account client = HttpContext.Session.Get<Account>("AccountKey");

            if (client == null)
            {
                client = new Account();
            }

            HttpContext.Session.Set<Account>("AccountKey", client);

            return View(client.MyWeather);
        }

        [HttpPost]
        public IActionResult SaveWeatherPreferences(WeatherPreference pref)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Account client = HttpContext.Session.Get<Account>("AccountKey");
            client.MyWeather = pref;
            HttpContext.Session.Set<Account>("AccountKey", client);

            return Ok();
        }

        //**********************************Log in Purpose *************//

        public ActionResult LogIn()
        {
            HttpContext.Session.SetString("phil", "false");
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string firstname, string password)
        {
            HttpContext.Session.SetString("phil", "false");
            if (_SM.LogIn(firstname, password))
            {
                _SM.GetAccount(firstname);
                HttpContext.Session.SetString("LoggedIn", "true");

                return RedirectToAction("Index", "Account");
            }
            return RedirectToAction("Create", "Home");
        }

        public ActionResult LogInFailed()
        {
            HttpContext.Session.SetString("Phil", "false");
            return View();
        }

        //*********************************REST and API Work***********//

        public async Task RestLogin(Account client)
        {
            var content = JsonConvert.SerializeObject(client);

            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var bytes = new ByteArrayContent(buffer);

            bytes.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await RestClient.PostAsync("http://www.LocationAlert.com/api/account", bytes);
            // load client data from response message here
            // save the data to session
            HttpContext.Session.Set<Account>("AccountKey", client);

        }
    }
}
