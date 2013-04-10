using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mrojas.Models;

namespace Mrojas.Controllers
{
    public class ProfileController : ApiController
    {
        [HttpGet]
        public Profile Profile(string token) 
        {
            var account = Account.AllAccounts.SingleOrDefault(a => a.Token == token);
            Profile result = null;
            if (account != null) 
            {
                result = Mrojas.Models.Profile.AllProfiles.SingleOrDefault(p => p.User.User == account.User);
            }

            if (result != null)
                return result;
            else
                throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
