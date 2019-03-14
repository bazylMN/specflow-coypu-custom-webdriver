using Coypu.Drivers;
using Coypu.Drivers.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDrivers
{
    public class CustomInternetExplorerWebDriver : SeleniumWebDriver
    {
        public CustomInternetExplorerWebDriver(Browser browser) : base(CustomProfile(), browser)
        {
        }

        private static IWebDriver CustomProfile()
        {
            InternetExplorerOptions internetExplorerOptions = new InternetExplorerOptions();
            internetExplorerOptions.InitialBrowserUrl = "http://localhost:8080";
            internetExplorerOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            internetExplorerOptions.EnsureCleanSession = true;

            return new InternetExplorerDriver(internetExplorerOptions);
        }

    }
}
