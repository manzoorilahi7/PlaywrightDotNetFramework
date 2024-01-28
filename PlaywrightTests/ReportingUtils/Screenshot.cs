using Allure.Net.Commons;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.ReportingUtils
{
    public class Screenshot
    {
        public static async Task CaptureScreeshot(IPage page, string stepDetail, Status status = Status.passed)
        {
            byte[] bytes = await page.ScreenshotAsync();
            AllureApi.AddAttachment(stepDetail, "image/png", bytes);
        }
    }
}
