using Microsoft.Playwright;

namespace PlaywrightTests
{
    public class Tests
    {

        [Test]
        public async Task LoginTest1()
        {

            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 50, Timeout = 80000 });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://opensource-demo.orangehrmlive.com/");
            await page.GetByPlaceholder("Username").FillAsync("Admin");
            await page.GetByPlaceholder("Password").FillAsync("admin123");
            await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
            

        }

        [Test]
        public async Task LoginTest2()
        {

            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 50, Timeout = 80000 });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://opensource-demo.orangehrmlive.com/");
            await page.GetByPlaceholder("Username").FillAsync("Admin");
            await page.GetByPlaceholder("Password").FillAsync("admin123");
            await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            var locator = page.Locator("h6");

            await Assertions.Expect(locator).ToHaveTextAsync("Dashboard");

            await page.CloseAsync();
        }
    }
}