using LocationAlert.Client.Models;
using System.Collections.Generic;
using System.Linq;
//using Lib = LocationAlert.Library.Models;

namespace LocationAlert.Client.ViewModels
{
    public class SuperModel
    {
        //private Lib.LibHelper _LH = Lib.LibHelper.Instance();

        //public void AddClient(Register r)
        //{
        //    _LH.AddClient(ClientToLibrary(new List<Register>() { r }).FirstOrDefault());
        //}

        //private List<Lib.Register> ClientToLibrary(List<Register> rs)
        //{
        //    var ls = new List<Lib.Register>();

        //    foreach (var item in rs)
        //    {
        //        ls.Add(new Lib.Register()
        //        {
        //            Firstname = item.FirstName,
        //            Email = item.Email.Address,
        //            Password = item.Password
        //        });
        //    }

        //    return ls;
        //}
        ////region to library to database  
        //public void AddRegion(Region r)
        //{
        //    _LH.AddRegion(RegiontToLibrary(new List<Region>() { r }).FirstOrDefault());
        //}

        //private List<Lib.Region> RegiontToLibrary(List<Region> rs)
        //{
        //    var ls = new List<Lib.Region>();

        //    foreach (var item in rs)
        //    {
        //        ls.Add(new Lib.Region()
        //        {
                   
        //            Latitude = (decimal)item.Latitude,
        //            Longitude = (decimal)item.Longitude,
        //            Radius = (long) item.Radius
        //        });
        //    }

        //    return ls;
        //}


        /////**************************************
        //public bool LogIn(string firstname, string password)
        //{
        //    return _LH.LogIn(firstname, password);
        //}

        //public Lib.Account GetAccount(string firstname)
        //{
        //    return _LH.GetAccount(firstname);
        //}
        
        //public Lib.Account AccountToLibrary(Account ca)
        //{
        //    var la = new Lib.Account()
        //    {
        //        FirstName = ca.FirstName,
        //        Password = ca.Password
        //    };
        //    return la;
        //}



    }
}
