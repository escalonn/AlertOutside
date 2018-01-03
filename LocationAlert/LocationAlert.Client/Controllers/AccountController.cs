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
            Account client = HttpContext.Session.Get<Account>("AccountKey");

            if ( client == null)
            {
                client = new Account();
                HttpContext.Session.Set<Account>("AccountKey", client);
            }

            return View(client);
        }
    }
}