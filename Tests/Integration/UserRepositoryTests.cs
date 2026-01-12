using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using user_management_api.data;
using user_management_api.model;
using user_management_api.repository;
using Xunit;

public class UserRepositoryTests
    : IClassFixture<PostgresContainerFixture>
{
    private readonly AppDbContext _context;
    private readonly UserRepository _repository;

    public UserRepositoryTests(PostgresContainerFixture fixture)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(fixture.Container.GetConnectionString())
            .Options;

        _context = new AppDbContext(options);
        _context.Database.Migrate();

        _repository = new UserRepository(_context);
    }

    [Fact]
    public async Task CreateAndGetUser_ShouldWork()
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = "yusuf",
            Email = "y@test.com",
            PasswordHash = "hash"
        };

        await _repository.CreateAsync(user);

        var result = await _repository.GetByUsernameAsync("yusuf");

        result.Should().NotBeNull();
        result!.UserName.Should().Be("yusuf");
    }
}
