using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace LocationAlert.Library.Models
{
    public class ServerTicker
    {
        public static string DataUrl { get; set; }
        private static HttpClient s_httpClient = new HttpClient();

        private static ServerTicker instance;
        public static List<Account> AccountList { get; set; }

        private TimeSpan startTimeSpan = TimeSpan.Zero;
        private TimeSpan intervalTimeSpan = TimeSpan.FromMinutes(5000);

        public static ServerTicker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServerTicker();
                }
                return instance;
            }

        }

        public void Start()
        {
            if (instance == null)
            {
                instance = new ServerTicker();
            }
        }

        private ServerTicker()
        {
            AccountList = new List<Account>();
            LoadAccounts();

            var timer = new System.Threading.Timer((e) =>
            {
                intervalTick();
            }, null, startTimeSpan, intervalTimeSpan);

        }

        // This gets run every (intervalTimeSpan) minutes
        private void intervalTick()
        {
            Console.WriteLine("Fire!");

            // Make sure accounts are synced with database
            LoadAccounts();
            // For every account registered to the service
            foreach (var account in AccountList )
            {
                if (account.LastPush == null)
                {
                    account.LastPush = DateTime.Now;
                }
                    // How long it has been since last push
                    var pushOffset = account.LastPush.AddHours(account.weatherPref.pushHours).AddMinutes(account.weatherPref.pushMinutes);

                    // If it has been too long since last push
                    if (pushOffset <= DateTime.Now)
                    {
                        var message = new Message(account.weatherPref, account.Email);

                        foreach (var region in account.Regions)
                        {

                            //weatherAPI call
                            WeatherApi ApiCall = new WeatherApi();

                            ApiCall.GetWeatherForecastAsync(region.Latitude, region.Longitude).GetAwaiter();

                            // Pass in all regions and the Api call object
                            message.ComposeMessage(account.Regions, ApiCall);

                        }

                        //send message
                        message.SendMessage();
                        account.LastPush = DateTime.Now;
                    }
            }
           
        }

        private void LoadAccounts()
        {
            // validate and talk to database
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, DataUrl + "/api/preferences");

            HttpResponseMessage res = s_httpClient.SendAsync(req).GetAwaiter().GetResult();
            if (!res.IsSuccessStatusCode)
            {
                // error
                return;
            }

            string content = res.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(content);

            AccountList = accounts;
        }

    }
}
