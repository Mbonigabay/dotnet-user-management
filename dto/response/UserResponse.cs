using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace user_management_api.dto.response
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}