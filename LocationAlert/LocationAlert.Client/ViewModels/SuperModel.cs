using LocationAlert.Client.Models;
using Lib = LocationAlert.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationAlert.Client.ViewModels
{
    public class SuperModel
    {
        private Lib.LibHelper _LH = Lib.LibHelper.Instance();

        public void AddClient(Register r)
        {
            _LH.AddClient(ClientToLibrary(new List<Register>() { r }).FirstOrDefault());
        }

        private List<Lib.Register> ClientToLibrary(List<Register> rs)
        {
            var ls = new List<Lib.Register>();

            foreach (var item in rs)
            {
                ls.Add(new Lib.Register()
                {
                    Firstname = item.Firstname,
                    Email = item.Email,
                    Password = item.Password
                });
            }

            return ls;
        }

        public bool LogIn(string firstname, string password)
        {
            return _LH.LogIn(firstname, password);
        }
        public Lib.Account GetAccount(string firstname)
        {
            return _LH.GetAccount(firstname);
        }


        public Lib.Account AccountToLibrary(Account ca)
        {
            var la = new Lib.Account()
            {
                FirstName = ca.FirstName,
                Password = ca.Password
            };
            return la;
        }


    }
}
