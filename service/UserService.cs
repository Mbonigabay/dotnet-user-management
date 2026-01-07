using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_management_api.model;

namespace user_management_api.service
{
    public class UserService
    {
         public static List<User> GetUsers()
        {
            List<User> users = new List<User>();

            var user1 = new User
            {
                FirstName = "Yusuf",
                LastName = "Mbonigaba",
                Email = "yusuf@example.com",
                UserName = "yusufm"
            };

            users.Add(user1);

            return users;
        }
    }
}