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
        await Page.GotoAsync("https://myjourneytowork-gus.azurewebsites.net/");
        await Page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);

        var welcomeMessage = await Page.QuerySelectorAsync("h1");
        Assert.AreEqual("Welcome", await welcomeMessage.TextContentAsync());

    }

}