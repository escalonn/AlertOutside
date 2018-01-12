using LocationAlert.Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LocationAlert.Client.ViewModels;

namespace LocationAlert.Client.Controllers
{
    public class AccountController : Controller
    {
        private static SuperModel _SM = new SuperModel();

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

            // Not sure if I have to 'save' this specific account object, too scared to delete
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
            return View(client.MyWeather);
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
    }
}
