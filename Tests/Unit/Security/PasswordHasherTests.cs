using FluentAssertions;
using user_management_api.auth;
using Xunit;

public class PasswordHasherTests
{
    [Fact]
    public void HashAndVerify_ShouldWork()
    {
        var password = "Secret123!";
        var hash = PasswordHasher.Hash(password);

        PasswordHasher.Verify(password, hash).Should().BeTrue();
        PasswordHasher.Verify("wrong", hash).Should().BeFalse();
    }
}
