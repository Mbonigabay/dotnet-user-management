using Microsoft.EntityFrameworkCore;
using user_management_api.model;

namespace user_management_api.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
    }
}
