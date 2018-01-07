﻿using System;
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
            Account client = HttpContext.Session.Get<Account>("AccountKey");

            // ID's are zero indexed!!
            for (int i = 0; i <= latData.Length -1; i++)
            {
                Region r = new Region(i, latData[i], lngData[i], radiusData[i]);

                if (r.ID >= client.RegionList.Count)
                {
                    client.RegionList.Add(r);
                }
                else
                {
                    client.RegionList[r.ID] = r;
                }

            }

            return View("Index");
        }
    }
}