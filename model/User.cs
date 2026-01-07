using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace user_management_api.model
{
    public class User
    {
        private string firstName;
        private string lastName;
        private string email;
        private string userName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}