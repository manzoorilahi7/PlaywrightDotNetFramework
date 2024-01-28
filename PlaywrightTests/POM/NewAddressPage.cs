using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.POM
{
    public class NewAddressPage
    {
        private readonly IPage _page;
        private readonly ILocator _uniqueAddressNameField;
        private readonly ILocator _firstNameField;
        private readonly ILocator _lastNameField;
        private readonly ILocator _addressField;
        private readonly ILocator _cityField;
        private readonly ILocator _countryField;
        private readonly ILocator _zipCodeField;
        private readonly ILocator _stateField;
        private readonly ILocator _phoneField;
        private readonly ILocator _saveBtn;

        public NewAddressPage(IPage page)
        {
            _page = page;
            _uniqueAddressNameField = _page.Locator("#address_label");
            _firstNameField = _page.Locator("#address_firstname");
            _lastNameField = _page.Locator("#address_lastname");
            _addressField = _page.Locator("#address_address1");
            _cityField = _page.Locator("#address_city");
            _stateField = _page.Locator("#address_state_id");
            _zipCodeField = _page.Locator("#address_zipcode");
            _countryField = _page.Locator("#address_country_id");
            _phoneField = _page.Locator("#address_phone");
            _saveBtn = _page.GetByRole(AriaRole.Button, new() { Name = "Save" });

        }

        public async Task AddNewAddress(string uniqueAddrName, string firstName, string lastName, string address, string city, string country, string zipCode, string state, string phone)
        {
            await _uniqueAddressNameField.FillAsync(uniqueAddrName);
            await _firstNameField.FillAsync(firstName);
            await _lastNameField.FillAsync(lastName);
            await _addressField.FillAsync(address);
            await _cityField.FillAsync(city);
            await _stateField.SelectOptionAsync(state);
            await _zipCodeField.FillAsync(zipCode);
            await _countryField.SelectOptionAsync(country);
            await _phoneField.FillAsync(phone);
            await _saveBtn.ClickAsync();
        }
    }
}
