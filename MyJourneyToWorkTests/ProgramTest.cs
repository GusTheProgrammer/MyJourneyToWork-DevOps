using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;


namespace MyJourneyToWorkTests;
[TestFixture]
public class ProgramTest
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
            });

        _client = _factory.CreateClient();
    }

    [TearDown]
    public void TearDown()
    {
        _client?.Dispose();
        _factory?.Dispose();
    }

    [Test]
    public async Task RazorPagesService_IsRegistered()
    {
        // Arrange
        var response = await _client.GetAsync("/"); // Replace with an actual Razor Page endpoint

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK)); // Modify as per actual behavior
    }

    [Test]
    public async Task ExceptionHandlerPage_IsUsedInNonDevelopmentEnvironment()
    {
        // Arrange - Set environment to Production or similar
        _factory.WithWebHostBuilder(builder =>
        {
            builder.UseEnvironment("Production");
        });

        // Act - Navigate to the error page
        var response = await _client.GetAsync("/error");
        var responseContent = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(responseContent.Contains("An error occurred while processing your request."), Is.True);
    }


    [Test]
    public async Task StaticFiles_AreServed()
    {
        // Arrange & Act
        var response = await _client.GetAsync("css/site.css");

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }




}
