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
        }

        private void LoadAccounts()
        {
            // load accounts from database
        }

    }
}
