using FluentAssertions;
using Moq;
using user_management_api.model;
using user_management_api.repository.interfaceRepository;
using user_management_api.service;
using Xunit;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _repo;
    private readonly Mock<TokenService> _mockTokenService;
    private readonly UserService _service;

    public UserServiceTests()
    {
        _repo = new Mock<IUserRepository>();
        _mockTokenService = new Mock<TokenService>();
        _service = new UserService(_repo.Object, _mockTokenService.Object);
    }

    [Fact]
    public async Task GetUserByUsername_ReturnsUser_WhenExists()
    {
        var user = new User { UserName = "yusuf" };

        _repo.Setup(r => r.GetByUsernameAsync("yusuf"))
             .ReturnsAsync(user);

        var result = await _service.GetUserByUsername("yusuf");

        result.Should().NotBeNull();
        result!.UserName.Should().Be("yusuf");
    }

    [Fact]
    public async Task GetUserByUsername_ReturnsNull_WhenNotFound()
    {
        _repo.Setup(r => r.GetByUsernameAsync(It.IsAny<string>()))
             .ReturnsAsync((User?)null);

        var result = await _service.GetUserByUsername("unknown");

        result.Should().BeNull();
    }
}
