using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using LocationAlert.Client.Models;
using LocationAlert.Client.ViewModels;
using Microsoft.AspNetCore.Http;

namespace LocationAlert.Client.Controllers
{
    public class HomeController : Controller
    {
        private static SuperModel _SM = new SuperModel();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

    //Registration form
        public ActionResult Create ()
        {
            return View(new Register());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Register r)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ArgumentException("you are not registered!!!");
                }

                _SM.AddClient(r);
                return RedirectToAction("Index", "Account");
                
            }
            catch
            {
                return View();
            }
        }

        /*LogIn Purpose

        public ActionResult LogInAccount()
        {
            HttpContext.Session.SetString("phil", "false");
            return View();
        }

        [HttpPost]
        public ActionResult LogInAccount(string firstname, string password)
        {
            HttpContext.Session.SetString("phil", "false");
            if (_SM.LogIn(firstname, password))
            {
                _SM.GetAccount(firstname);
                HttpContext.Session.SetString("LoggedIn", "true");

                return RedirectToAction("Index", "Account");
            }
            return RedirectToAction("LogIn", "Home");
        }

        public ActionResult LogInFailed()
        {
            HttpContext.Session.SetString("Phil", "false");
            return View();
        }
        */



        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
