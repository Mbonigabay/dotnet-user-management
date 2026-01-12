using user_management_api.data;
using user_management_api.model;
using Microsoft.EntityFrameworkCore;
using user_management_api.repository.interfaceRepository;
using user_management_api.dto.response;
using user_management_api.dto.request;
using user_management_api.mappings;
using user_management_api.auth;

namespace user_management_api.service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenService _tokenService;

        public UserService(IUserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<AuthResponse?> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null)
                return null;

            // ⚠️ TEMP — replace with hashed password check
            if (!PasswordHasher.Verify(password, user.PasswordHash))
                return null;

            return _tokenService.GenerateToken(user);
        }


        public async Task<List<UserResponse>> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();

            return UserMapper.ToResponseList(users);
        }

        public async Task<UserResponse?> GetUserByUsername(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            if (user == null)
                return null;

            return UserMapper.ToResponse(user);
        }


        public async Task<UserResponse> CreateUser(CreateUserRequest request)
        {
            var user = UserMapper.ToEntity(request);

            var savedUser = await _userRepository.CreateAsync(user);

            return UserMapper.ToResponse(savedUser);
        }

    }
}
