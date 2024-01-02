using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task HomepageHasWelcomeHeaderTag()
    {
        await Page.GotoAsync("https://myjourneytowork-gus-qa.azurewebsites.net/");
        await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

        var welcomeMessage = await Page.QuerySelectorAsync("h1");
        Assert.AreEqual("Welcome", await welcomeMessage.TextContentAsync());

    }

    [Test]
    public async Task PrivacyPageHasHeaderTag()
    {
        await Page.GotoAsync("https://myjourneytowork-gus-qa.azurewebsites.net/");
        await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

        // Navigate to the privacy page
        await Page.GetByRole(AriaRole.List).GetByRole(AriaRole.Link, new() { Name = "Privacy" }).ClickAsync();

        // Assert page is /Privacy
        Assert.AreEqual("https://myjourneytowork-gus-qa.azurewebsites.net/Privacy", Page.Url);

        // Assert the privacy header is correct
        var privacyHeader = await Page.QuerySelectorAsync("h1");
        Assert.AreEqual("Privacy Policy", await privacyHeader.TextContentAsync());


    }

    [Test]
    public async Task CalculateDeiselMiles()
    {
        // Navigate to the homepage
        await Page.GotoAsync("https://myjourneytowork-gus-qa.azurewebsites.net/");

        // Navigate to the calculator page
        await Page.GetByRole(AriaRole.Link, new() { Name = "Calculator" }).ClickAsync();

        // Assert page is /Calculator
        Assert.AreEqual("https://myjourneytowork-gus-qa.azurewebsites.net/Calculator", Page.Url);

        // Enter the number of days you work
        await Page.GetByLabel("Enter the number of days you").ClickAsync();
        // Fill the number of days you work
        await Page.GetByLabel("Enter the number of days you").FillAsync("5");

        // Enter the number of miles you travel
        await Page.GetByLabel("Enter Your Distance to work (").ClickAsync();

        // Fill the number of miles you travel
        await Page.GetByLabel("Enter Your Distance to work (").FillAsync("25");

        // Select the distance unit
        await Page.GetByLabel("Select A Distance Measurement:").SelectOptionAsync("Miles");

        // Select the transport mode
        await Page.GetByLabel("Select A Transport mode:").SelectOptionAsync("Diesel");

        // Click the calculate button
        await Page.GetByRole(AriaRole.Button, new() { Name = "Calculate" }).ClickAsync();

        // Assert the sustainability weighting is correct
        string sustainabilityWeighting = await Page.GetByText("Your Sustainability Weighting: 2500").InnerTextAsync();
        Assert.AreEqual("Your Sustainability Weighting: 2500", sustainabilityWeighting);

        // Assert the estimated transportation cost is correct
        string estimatedTransportationCost = await Page.GetByText("Estimated Transportation Cost: € 25").InnerTextAsync();
        Assert.AreEqual("Estimated Transportation Cost: € 25", estimatedTransportationCost);
    }

    [Test]
    public async Task CalculatePetrolKilometers()
    {
        // Navigate to the homepage
        await Page.GotoAsync("https://myjourneytowork-gus-qa.azurewebsites.net/");

        // Navigate to the calculator page
        await Page.GetByRole(AriaRole.Link, new() { Name = "Calculator" }).ClickAsync();

        // Assert page is /Calculator
        Assert.AreEqual("https://myjourneytowork-gus-qa.azurewebsites.net/Calculator", Page.Url);

        // Enter the number of days you work
        await Page.GetByLabel("Enter the number of days you").ClickAsync();
        // Fill the number of days you work
        await Page.GetByLabel("Enter the number of days you").FillAsync("5");

        // Enter the number of miles you travel
        await Page.GetByLabel("Enter Your Distance to work (").ClickAsync();

        // Fill the number of miles you travel
        await Page.GetByLabel("Enter Your Distance to work (").FillAsync("25");

        // Select the distance unit
        await Page.GetByLabel("Select A Distance Measurement:").SelectOptionAsync("Kilometers");

        // Select the transport mode
        await Page.GetByLabel("Select A Transport mode:").SelectOptionAsync("Petrol");

        // Click the calculate button
        await Page.GetByRole(AriaRole.Button, new() { Name = "Calculate" }).ClickAsync();

        // Assert the sustainability weighting is correct
        string sustainabilityWeighting = await Page.GetByText("Your Sustainability Weighting: 1242.742384474668").InnerTextAsync();
        Assert.AreEqual("Your Sustainability Weighting: 1242.742384474668", sustainabilityWeighting);

        // Assert the estimated transportation cost is correct
        string estimatedTransportationCost = await Page.GetByText("Estimated Transportation Cost: € 12.427423844746679").InnerTextAsync();
        Assert.AreEqual("Estimated Transportation Cost: € 12.427423844746679", estimatedTransportationCost);
    }

    [Test]
    public async Task CalculateBusKilometers()
    {
        // Navigate to the homepage
        await Page.GotoAsync("https://myjourneytowork-gus-qa.azurewebsites.net/");

        // Navigate to the calculator page
        await Page.GetByRole(AriaRole.Link, new() { Name = "Calculator" }).ClickAsync();

        // Assert page is /Calculator
        Assert.AreEqual("https://myjourneytowork-gus-qa.azurewebsites.net/Calculator", Page.Url);

        // Enter the number of days you work
        await Page.GetByLabel("Enter the number of days you").ClickAsync();
        // Fill the number of days you work
        await Page.GetByLabel("Enter the number of days you").FillAsync("5");

        // Enter the number of miles you travel
        await Page.GetByLabel("Enter Your Distance to work (").ClickAsync();

        // Fill the number of miles you travel
        await Page.GetByLabel("Enter Your Distance to work (").FillAsync("25");

        // Select the distance unit
        await Page.GetByLabel("Select A Distance Measurement:").SelectOptionAsync("Kilometers");

        // Select the transport mode
        await Page.GetByLabel("Select A Transport mode:").SelectOptionAsync("Bus");

        // Click the calculate button
        await Page.GetByRole(AriaRole.Button, new() { Name = "Calculate" }).ClickAsync();

        // Assert the sustainability weighting is correct
        string sustainabilityWeighting = await Page.GetByText("Your Sustainability Weighting: 466.02839417800044").InnerTextAsync();
        Assert.AreEqual("Your Sustainability Weighting: 466.02839417800044", sustainabilityWeighting);

        // Assert the estimated transportation cost is correct
        string estimatedTransportationCost = await Page.GetByText("Estimated Transportation Cost: € 2.7").InnerTextAsync();
        Assert.AreEqual("Estimated Transportation Cost: € 2.7", estimatedTransportationCost);
    }

    [Test]
    public async Task CalcualteElectricMiles()
    {
        // Navigate to the homepage
        await Page.GotoAsync("https://myjourneytowork-gus-qa.azurewebsites.net/");

        // Navigate to the calculator page
        await Page.GetByRole(AriaRole.Link, new() { Name = "Calculator" }).ClickAsync();

        // Assert page is /Calculator
        Assert.AreEqual("https://myjourneytowork-gus-qa.azurewebsites.net/Calculator", Page.Url);

        // Enter the number of days you work
        await Page.GetByLabel("Enter the number of days you").ClickAsync();
        // Fill the number of days you work
        await Page.GetByLabel("Enter the number of days you").FillAsync("5");

        // Enter the number of miles you travel
        await Page.GetByLabel("Enter Your Distance to work (").ClickAsync();

        // Fill the number of miles you travel
        await Page.GetByLabel("Enter Your Distance to work (").FillAsync("25");

        // Select the distance unit
        await Page.GetByLabel("Select A Distance Measurement:").SelectOptionAsync("Miles");

        // Select the transport mode
        await Page.GetByLabel("Select A Transport mode:").SelectOptionAsync("Electric");

        // Click the calculate button
        await Page.GetByRole(AriaRole.Button, new() { Name = "Calculate" }).ClickAsync();

        // Assert the sustainability weighting is correct
        string sustainabilityWeighting = await Page.GetByText("Your Sustainability Weighting: 1000").InnerTextAsync();
        Assert.AreEqual("Your Sustainability Weighting: 1000", sustainabilityWeighting);

        // Assert the estimated transportation cost is correct
        string estimatedTransportationCost = await Page.GetByText("Estimated Transportation Cost: € 15").InnerTextAsync();
        Assert.AreEqual("Estimated Transportation Cost: € 15", estimatedTransportationCost);
    }

    [Test]
    public async Task CalculateWalkingMiles()
    {
        // Navigate to the homepage
        await Page.GotoAsync("https://myjourneytowork-gus-qa.azurewebsites.net/");

        // Navigate to the calculator page
        await Page.GetByRole(AriaRole.Link, new() { Name = "Calculator" }).ClickAsync();

        // Assert page is /Calculator
        Assert.AreEqual("https://myjourneytowork-gus-qa.azurewebsites.net/Calculator", Page.Url);

        // Enter the number of days you work
        await Page.GetByLabel("Enter the number of days you").ClickAsync();
        // Fill the number of days you work
        await Page.GetByLabel("Enter the number of days you").FillAsync("5");

        // Enter the number of miles you travel
        await Page.GetByLabel("Enter Your Distance to work (").ClickAsync();

        // Fill the number of miles you travel
        await Page.GetByLabel("Enter Your Distance to work (").FillAsync("25");

        // Select the distance unit
        await Page.GetByLabel("Select A Distance Measurement:").SelectOptionAsync("Miles");

        // Select the transport mode
        await Page.GetByLabel("Select A Transport mode:").SelectOptionAsync("Walking");

        // Click the calculate button
        await Page.GetByRole(AriaRole.Button, new() { Name = "Calculate" }).ClickAsync();

        // Assert the sustainability weighting is correct
        string sustainabilityWeighting = await Page.GetByText("Your Sustainability Weighting: 1.25").InnerTextAsync();
        Assert.AreEqual("Your Sustainability Weighting: 1.25", sustainabilityWeighting);

        // Assert the estimated transportation cost is correct
        string estimatedTransportationCost = await Page.GetByText("Estimated Transportation Cost: € 0").InnerTextAsync();
        Assert.AreEqual("Estimated Transportation Cost: € 0", estimatedTransportationCost);
    }


}