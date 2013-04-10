using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mrojas.Models;

namespace Mrojas.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public object Login(Account value)
        {

            bool success = false;
            var account = Account.AllAccounts.SingleOrDefault(a => a.User == value.User);
            if (account != null) 
            { 
              if(account.Password == value.Password)
                success = true;
              return new {result = success, token = account.Token };
            }

            return new {result = success, message = "user does not exist"};
        }

        [HttpDelete]
        public object Logout(string token) 
        {
            var account = Account.AllAccounts.SingleOrDefault(a => a.Token == token);

            if (account != null)
            {
                account.Token = string.Empty;
                return true;
            }
            else 
                return false;
        }
    }
}
