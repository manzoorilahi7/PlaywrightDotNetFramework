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

        #region LoginTestWithDifferentBrowsers
        /// <summary>
        /// Login test with different browsers and configs - headless, Channel, Slowmo.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task LoginTestWithDifferentBrowsers()
        {

            var playwright = await Playwright.CreateAsync();
            //var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, Channel = "chrome", SlowMo = 500, Timeout = 80000 });

            //Different browsers
            //var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, Channel = "msedge", SlowMo = 500, Timeout = 80000 });
            //var browser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 500, Timeout = 80000 });
            var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 500, Timeout = 80000 });


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
        #endregion

        #region LoginTestWithVideoRec
        /// <summary>
        /// Login test with different browsers and configs - headless, Channel, Slowmo.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task LoginTestWithVideoRec()
        {

            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 500, Timeout = 80000 });         

            var context = await browser.NewContextAsync(new()
            {
                RecordVideoDir = "Video/",
                RecordVideoSize = new RecordVideoSize() { Width = 1920, Height = 1080},
                ViewportSize = new ViewportSize() { Width = 1920, Height = 1080 }
            });
            
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://opensource-demo.orangehrmlive.com/");
            await page.GetByPlaceholder("Username").FillAsync("Admin");
            await page.GetByPlaceholder("Password").FillAsync("admin123");
            await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            var locator = page.Locator("h6");

            await Assertions.Expect(locator).ToHaveTextAsync("Dashboard");

            await page.CloseAsync();
        }
        #endregion

    }
}