using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LocationAlert.Library.Models
{
    public class ServerTicker
    {
        private static ServerTicker instance;
        public List<Account> AcountList { get; set; }

        private TimeSpan startTimeSpan = TimeSpan.Zero;
        private TimeSpan intervalTimeSpan = TimeSpan.FromMinutes(10);

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
            AcountList = new List<Account>();
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

            // Make sure accounts is synced with database
            LoadAccounts();
            // For every account registed to the service
            foreach (var account in AcountList )
            {
                if (account.LastPush != null)
                {
                    // How long it has been since last push
                    var pushOffset = account.LastPush.AddHours(account.weatherPref.pushHours).AddMinutes(account.weatherPref.pushMinutes);

                    // If it has been too long since last push
                    if (pushOffset >= DateTime.Now)
                    {
                        var message = new Message(account.weatherPref, account.Email);

                        foreach (var region in account.Regions)
                        {

                            //weatherAPI call
                            // need to pass in parsed JSON data too
                            message.ComposeMessage(account.Regions);
                        }
                            //send message
                        account.LastPush = DateTime.Now;
                    }
                }
            }
           
        }

        private void LoadAccounts()
        {
            // load accounts from database
        }

    }
}
