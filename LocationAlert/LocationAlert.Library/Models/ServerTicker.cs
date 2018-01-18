using System;
using System.Collections.Generic;
using System.Text;

namespace LocationAlert.Library.Models
{
    public class ServerTicker
    {
        private static ServerTicker instance;
        public List<Account> AcountList { get; set; }

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
        }

        private void LoadAccounts()
        {
            // load accounts from database
        }

    }
}
