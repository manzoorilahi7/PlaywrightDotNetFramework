using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.POM
{
    public  class LoginPage : PageTest
    {
        private readonly IPage _page;
        private readonly ILocator _emailTxtField;
        private readonly ILocator _passwordTxtField;
        private readonly ILocator _loginBtn;

        public LoginPage(IPage page)
        {
            _page = page;
            _emailTxtField = _page.Locator("#spree_user_email");
            _passwordTxtField = _page.Locator("#spree_user_password");
            _loginBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        }

        public async Task Login(string url, string email, string password)
        {
            await _page.GotoAsync(url);
            await _emailTxtField.FillAsync(email);
            await _passwordTxtField.FillAsync(password);
            await _loginBtn.ClickAsync();
        }
    }
}
