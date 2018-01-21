using LocationAlert.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationAlert.Data.Service.Models
{
    public static class DataHelper
    {
        public static Client convert(Account serviceClient)
        {
            var dataClient = new Client();

            dataClient.Email = serviceClient.Email;
            // TODO
            //dataClient.Preference.WeatherPreference.
            return dataClient;
        }
    }
}
