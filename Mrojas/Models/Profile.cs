using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mrojas.Models
{
    public class Profile
    {
        public static IEnumerable<Profile> AllProfiles { get; private set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Account User {get; set; }

        public static void LoadProfiles()
        {
            var result = new List<Profile>();
            result.Add(new Profile()
            {
                Name = "Manuel",
                LastName = "Rojas",
                Email = "mrojas@gmail.com",
                Address = "Desamparados",
                Phone = "2276 8411",
                User = Account.AllAccounts.SingleOrDefault(u => u.User == "mrojas")

            });
            result.Add(new Profile()
            {
                Name = "Jeudy",
                LastName = "Blanco",
                Email = "jdeudy@gmail.com",
                Address = "Cartago",
                Phone = "2276 8411",
                User = Account.AllAccounts.SingleOrDefault(u => u.User == "jblanco")
            });

            Profile.AllProfiles = result;
        }

    }
}