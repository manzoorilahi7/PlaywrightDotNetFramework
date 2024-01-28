using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.POM
{
    public class AccountPage : PageTest
    {
        private readonly IPage _page;
        private readonly ILocator _addNewAddressLink;

        public AccountPage(IPage page)
        {
            _page = page;
            _addNewAddressLink = _page.GetByText("Add new address");
        }

        [AllureStep]
        public async Task VerifyLoggedIn()
        {
            await Expect(_page.GetByText("Logged in successfully")).ToBeVisibleAsync();
        }

        [AllureStep]
        public async Task NavigateToAddNewAddressPage()
        {
            await _addNewAddressLink.ClickAsync();
        }

        [AllureStep]
        public async Task NavigateToCart()
        {
            await _page.GetByLabel("Cart").ClickAsync();
        }
    }
}
