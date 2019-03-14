using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDrivers
{
    public class CustomFirefoxHeadlessWebDriver : SeleniumWebDriver
    {

        public CustomFirefoxHeadlessWebDriver(Browser browser) : base(CustomProfile(), browser)
        {
        }

        private static IWebDriver CustomProfile()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArguments("--headless");
            firefoxOptions.SetPreference("app.update.enabled", false);

            return new FirefoxDriver(firefoxOptions);
        }
    }
}
