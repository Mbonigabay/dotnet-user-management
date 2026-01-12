using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace user_management_api.dto.response
{
    public class AuthResponse
    {
        public string Token { get; set; } = null!;
        public DateTime ExpiresAt { get; set; }
    }
}