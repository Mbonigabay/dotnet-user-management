using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_management_api.model;

namespace user_management_api.repository.interfaceRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByUsernameAsync(string username);
        Task<User> CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}