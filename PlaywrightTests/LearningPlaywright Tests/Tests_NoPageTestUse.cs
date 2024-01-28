using Microsoft.Playwright;
using System.Runtime.InteropServices;

namespace PlaywrightTests
{
    public class Tests_NoPageTestUse
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

        [Test]
        public async Task TraceTC()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, SlowMo = 1});
            var context = await browser.NewContextAsync();

            await context.Tracing.StartAsync(new() 
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });

            var page = await browser.NewPageAsync();
            await page.SetViewportSizeAsync(1920, 1080);

            await page.GotoAsync("https://demo.spreecommerce.org/login");
            await page.FillAsync("#spree_user_email", "manzoorchamp91@gmail.com");
            await page.FillAsync("#spree_user_password", "shopping123");
            await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();


            await context.Tracing.StopAsync(new()
            {
                Path = "Trace/trace.zip"
            });

            await context.CloseAsync();
            await browser.CloseAsync();
        }

        [Test]
        public async Task SaveStateTC()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, Timeout = 80000 });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://opensource-demo.orangehrmlive.com/");
            await page.GetByPlaceholder("Username").FillAsync("Admin");
            await page.GetByPlaceholder("Password").FillAsync("admin123");
            await page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();

            await context.StorageStateAsync(new()
            {
                Path = @"state\state_login.json"
            });

            await context.CloseAsync();
            await browser.CloseAsync();
        }

        [Test]
        public async Task RetrieveStateTC()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, Timeout = 80000 });
            var context = await browser.NewContextAsync(new()
            {
                StorageStatePath = @"state\state_login.json"
            });
            
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/admin/viewSystemUsers");
            var locator = page.GetByRole(AriaRole.Button, new() { Name = "Search"});

            await Assertions.Expect(locator).ToHaveTextAsync("Search");

        }

        [Test]
        public async Task Login_CodeGenTC()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, Timeout = 80000 });
            var context = await browser.NewContextAsync();
            var Page = await context.NewPageAsync();

            await Page.GotoAsync("https://demo.spreecommerce.org/login");
            await Page.GetByPlaceholder("Email").ClickAsync();
            await Page.GetByPlaceholder("Email").FillAsync("manzoorchamp91@gmail.com");
            await Page.GetByPlaceholder("Password").ClickAsync();
            await Page.GetByPlaceholder("Password").FillAsync("shopping123");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
            await Page.GetByText("Logged in successfully").ClickAsync();
        }
    }
}