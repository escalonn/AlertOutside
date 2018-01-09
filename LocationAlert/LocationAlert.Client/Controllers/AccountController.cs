using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using LocationAlert.Client.Models;
using LocationAlert.Client.ViewModels;

namespace LocationAlert.Client.Controllers
{
    public class AccountController : Controller
    {
        private static SuperModel _SM = new SuperModel();
        public IActionResult Index()
        {
            Account client = HttpContext.Session.Get<Account>("AccountKey");

            if ( client == null)
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
        //**********************************Log in Purpose *************//


        public IActionResult EditRegion(string[] latData, string[] lngData, string[] radiusData)
        {
            return View("Index");
        }
    }
}