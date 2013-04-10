using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Mrojas.Models
{
    public class Account
    {
        public static IEnumerable<Account> AllAccounts { get; private set; }

        public string User { get; set; }
        public string Password { get; set; }

        private string token;
        public string Token
        {
            get
            {
                if (token == null)
                {
                    token = Guid.NewGuid().ToString().Replace("-", "");
                }

                return token;
            }

            set 
            {
                if (value != null) 
                {
                    this.token = value;
                }
            }
        }

        public static void LoadAccounts()
        {
            var result = new List<Account>();
            result.Add(new Account()
            {
                User = "mrojas",
                Password = "pazz"
            });
            result.Add(new Account()
            {
                User = "jblanco",
                Password = "pazz"
            });

            Account.AllAccounts = result;
        }

    }
}