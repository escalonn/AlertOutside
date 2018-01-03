using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace LocationAlert.Client.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("SessionKey", 5);

            return View();

        }
    }
}