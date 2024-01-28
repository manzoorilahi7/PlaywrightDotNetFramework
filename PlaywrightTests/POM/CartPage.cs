using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.POM
{
    public class CartPage
    {
        private readonly IPage _page;
        private readonly ILocator _promocodeTxtBox;
        private readonly ILocator _checkoutBtn;

        public CartPage(IPage page)
        {
            _page = page;
            _promocodeTxtBox = _page.GetByPlaceholder("ADD PROMO CODE");
            _checkoutBtn = _page.Locator("#checkout-link");
        }

        public async Task AddPromoCode(string promoCode)
        {
            await _promocodeTxtBox.FillAsync(promoCode);
        }

        public async Task ProceedToCheckOut()
        {
            await _checkoutBtn.ClickAsync();
        }
    }
}
