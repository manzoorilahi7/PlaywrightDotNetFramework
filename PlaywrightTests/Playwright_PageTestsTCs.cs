using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
