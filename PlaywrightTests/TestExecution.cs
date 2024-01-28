using Microsoft.Playwright.NUnit;
using PlaywrightTests.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests
{
    [TestFixture]
    public class TestExecution : PageTest
    {
        [Test]
        public async Task LoginUsingPOMTest()
        {
            LoginPage loginPage = new LoginPage(Page);
            AccountPage accountPage = new AccountPage(Page);

            await loginPage.Login("https://demo.spreecommerce.org/login", "manzoorchamp91@gmail.com", "shopping123");
            await accountPage.VerifyLoggedIn();
        }

        [Test]
        public async Task AddNewAddressTest()
        {
            LoginPage loginPage = new LoginPage(Page);
            AccountPage accountPage = new AccountPage(Page);
            NewAddressPage newAddressPage = new NewAddressPage(Page);   

            await loginPage.Login("https://demo.spreecommerce.org/login", "manzoorchamp91@gmail.com", "shopping123");
            await accountPage.VerifyLoggedIn();
            await accountPage.NavigateToAddNewAddressPage();

            await newAddressPage.AddNewAddress("Office", "Zoor", "TestLast", "Area 52 last lane", "Cali", "Canada", "5756734", "Idaho", "9156456456546");
        }

        [Test]
        public async Task CartNavigationTest()
        {
            LoginPage loginPage = new LoginPage(Page);
            AccountPage accountPage = new AccountPage(Page);
            CartPage cartPage = new CartPage(Page);
            

            await loginPage.Login("https://demo.spreecommerce.org/login", "manzoorchamp91@gmail.com", "shopping123");
            await accountPage.VerifyLoggedIn();
            await accountPage.NavigateToCart();

            await cartPage.AddPromoCode("Offer Test 456");
            await cartPage.ProceedToCheckOut();
        }
    }
}
