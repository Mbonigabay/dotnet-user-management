using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace user_management_api.dto.request
{
    public class LoginRequest
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}