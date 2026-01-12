using System.Net;
using FluentAssertions;
using Xunit;

public class AuthTests
    : IClassFixture<PostgresContainerFixture>
{
    private readonly HttpClient _client;

    public AuthTests(PostgresContainerFixture fixture)
    {
        var factory = new CustomWebApplicationFactory(
            fixture.Container.GetConnectionString());

        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ProtectedEndpoint_Returns401_WithoutToken()
    {
        var response = await _client.GetAsync("/api/users");

        response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}
