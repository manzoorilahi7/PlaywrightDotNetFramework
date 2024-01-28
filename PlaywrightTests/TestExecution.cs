using Allure.Net.Commons;
using Microsoft.Playwright.NUnit;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using PlaywrightTests.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests
{
    [TestFixture]
    [AllureNUnit]
    public class TestExecution : PageTest
    {
        [AllureStep("Logging in and verifying if successfully logged in")]
        [AllureOwner("Manzoor E Ilahi")]
        [Test]       
        public async Task LoginUsingPOMTest()
        {
            LoginPage loginPage = new LoginPage(Page);
            AccountPage accountPage = new AccountPage(Page);

            await loginPage.Login("https://demo.spreecommerce.org/login", "manzoorchamp91@gmail.com", "shopping123");
            await accountPage.VerifyLoggedIn();
        }

        [Test]
        [AllureStep]
        [AllureOwner("Manzoor E Ilahi")]
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
        [AllureStep]
        [AllureDescription("This test case navigates to the cart page and clicks on checkout.")]
        [AllureOwner("Manzoor E Ilahi")]
        [AllureTag("SmokeTest", "Regression")]
        [Category("Cart")]
        [AllureSuite("Smoke test Suite")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureLink("Application under test: ", "https://demo.spreecommerce.org/")]
        [AllureLink("Test case developed by: Manzoor", "https://github.com/manzoorilahi7")]
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
