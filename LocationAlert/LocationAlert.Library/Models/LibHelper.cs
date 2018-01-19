using LocationAlert.Data;
using LocationAlert.Data.Models;
using Dac = LocationAlert.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace LocationAlert.Library.Models
{
    public class LibHelper
    {
        public bool LoggedIn = false;
        private static LibHelper _LH;
        private static LocationAlertDBContext _DB = new LocationAlertDBContext();
        private LibHelper(){}

        public static LibHelper Instance()
        {
            if (_LH == null)
            {
                _LH = new LibHelper();
            }

            return _LH;

        }

        public bool AddClient(Register r)
        {
            try
            {
                if (r == null)
                {
                    return false;
                }

                var ps = ClientToData(new List<Register>() { r }).FirstOrDefault();
              
                _DB.Client.Add(ps);
                _DB.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        private List<Dac.Client> ClientToData(List<Register> ps)
        {
            var ls = new List<Dac.Client>();

            foreach (var item in ps)
            {
                ls.Add(new Dac.Client()
                {
                    FirstName = item.Firstname,
                    Email = item.Email,
                    PasswordHash = item.Password,
                    DateModified = DateTime.Now,
                   
                });
            }

            return ls;
        }

        //Library to data--------------------
        public bool AddRegion(Region r)
        {
            try
            {
                if (r == null)
                {
                    return false;
                }

                var ps = RegionToData(new List<Region>() { r }).FirstOrDefault();

                _DB.Region.Add(ps);
                _DB.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        private List<Dac.Region> RegionToData(List<Region> ps)
        {
            var ls = new List<Dac.Region>();

            foreach (var item in ps)
            {
                ls.Add(new Dac.Region()
                {
                    Longitude = item.Longitude,
                    Latitude = item.Latitude,
                    Radius = item.Radius,
                  

                });
            }

            return ls;
        }

        //--------------------------------------------------------------------------
        public bool LogIn(string firstname, string password)
        {
            if (_DB.Client.Any(acc => acc.FirstName == firstname && acc.PasswordHash == password))
            {
                LoggedIn = true;
                return true;
            }
            return false;
        }

        public Account GetAccount(string firstName)
        {
            var dba = (from acc in _DB.Client
                       where acc.FirstName == firstName
                       select acc).First();

            return AccountToLibrary(dba);
        }

        public Account AccountToLibrary(Dac.Client dba)
        {
            var la = new Account()
            {
                FirstName = dba.FirstName,
                Password = dba.PasswordHash
            };
            return la;
        }
    }
}
