using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlaywrightTests
{
    [TestFixture]
    public class Playwright_PageTestsTCs : PageTest
    {
        [Test]
        public async Task LoginTestUsingPageTest()
        {
            await Page.GotoAsync("https://opensource-demo.orangehrmlive.com/");
            await Expect(Page).ToHaveTitleAsync("OrangeHRM");
            await Page.GetByPlaceholder("Username").FillAsync("Admin");
            await Page.GetByPlaceholder("Password").FillAsync("admin123");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
            await Expect(Page).ToHaveURLAsync("https://opensource-demo.orangehrmlive.com/web/index.php/dashboard/index");
        }

        [Test]
        public async Task ExploringDifferentLocators_PlaceHolderTest()
        {
            await Page.GotoAsync("https://demoqa.com/text-box");
            await Page.GetByPlaceholder("Full Name").FillAsync("Zoor Test");
            await Page.GetByPlaceholder("name@example.com").FillAsync("zoortest@hotmail.com");
            await Page.GetByPlaceholder("Current Address").FillAsync("Area 52");

        }

        [Test]
        public async Task ExploringDifferentLocators_TextTest()
        {
            await Page.GotoAsync("https://demoqa.com/links");
            await Page.GetByText("Created").ClickAsync();
        }

        [Test]
        public async Task ExploringDifferentLocators_AltTextTest()
        {
            await Page.GotoAsync("https://playwright.dev/dotnet/docs/codegen-intro");
            await Page.GetByAltText("playwright logo").First.ClickAsync();
        }

        [Test]
        public async Task ExploringDifferentLocators_LabelTest()
        {
            await Page.GotoAsync("https://playwright.dev/dotnet/docs/locators#locate-by-label");
            await Page.GetByLabel("Password").FillAsync("Pass14345");
        }

        [Test]
        public async Task ExploringDifferentLocators_TitleTest()
        {
            await Page.GotoAsync("https://playwright.dev/dotnet/docs/locators#locate-by-title");
            await Expect(Page.GetByTitle("Issues count")).ToHaveTextAsync("25 issues");
        }

        [Test]
        public async Task ExploringDifferentLocators_RoleTest()
        {
            await Page.GotoAsync("https://playwright.dev/dotnet/docs/locators#locate-by-role");

            await Expect(Page
                        .GetByRole(AriaRole.Heading, new() { Name = "Sign up" }))
                        .ToBeVisibleAsync();

            await Page
                .GetByRole(AriaRole.Checkbox, new() { Name = "Subscribe" })
                .CheckAsync();

            await Page
                .GetByRole(AriaRole.Button, new()
                {
                    NameRegex = new Regex("submit", RegexOptions.IgnoreCase)
                })
                .ClickAsync();
        }
    }
}
