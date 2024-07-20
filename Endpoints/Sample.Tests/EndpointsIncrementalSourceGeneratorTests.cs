using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Endpoints.Tests;

public class SampleEndpointTests
{
    private readonly WebApplicationFactory<Program> _factory = new();
    
    [InlineData("/weather", "Hello world!")]
    [InlineData("/add?a=1&b=2", "3")]
    [Theory]
    public async Task Endpoints_Should_ReturnOK(string endpoint, string expectedResponse)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(endpoint);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(expectedResponse, await response.Content.ReadAsStringAsync());
    }
}