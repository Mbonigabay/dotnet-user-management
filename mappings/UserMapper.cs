using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_management_api.auth;
using user_management_api.dto.request;
using user_management_api.dto.response;
using user_management_api.model;

namespace user_management_api.mappings
{
    public class UserMapper
    {
        public static User ToEntity(CreateUserRequest request)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                PasswordHash = PasswordHasher.Hash(request.Password)
            };
        }

        public static UserResponse ToResponse(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName
            };
        }

        public static List<UserResponse> ToResponseList(IEnumerable<User> users)
        {
            return users.Select(ToResponse).ToList();
        }
    }
}