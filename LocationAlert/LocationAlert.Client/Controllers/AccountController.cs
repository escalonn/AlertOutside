using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using LocationAlert.Client.Models;

namespace LocationAlert.Client.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            // Session serialization example
            HttpContext.Session.Set<Account>("key", new Account());

            return View();

        }
    }
}