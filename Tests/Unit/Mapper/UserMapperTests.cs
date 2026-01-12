using FluentAssertions;
using user_management_api.auth;
using user_management_api.dto.request;
using user_management_api.mappings;
using user_management_api.model;
using Xunit;

public class UserMapperTests
{
    [Fact]
    public void ToEntity_ShouldHashPassword()
    {
        var request = new CreateUserRequest
        {
            FirstName = "Yusuf",
            LastName = "Mbonigaba",
            UserName = "yusuf",
            Email = "yusuf@test.com",
            Password = "Password123"
        };

        var user = UserMapper.ToEntity(request);

        user.PasswordHash.Should().NotBe("Password123");
        PasswordHasher.Verify("Password123", user.PasswordHash).Should().BeTrue();
    }

    [Fact]
    public void ToResponse_ShouldNotExposePassword()
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = "yusuf",
            Email = "yusuf@test.com",
            PasswordHash = "hash"
        };

        var response = UserMapper.ToResponse(user);

        response.UserName.Should().Be("yusuf");
    }
}
