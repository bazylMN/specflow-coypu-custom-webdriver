using Coypu;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using WebDrivers;

namespace specflow_coypu_custom_webdriver.WebDrivers
{
    [Binding]
    public class BrowserSessionManager
    {

        private BrowserSession browser;

        public BrowserSession Browser()
        {
            return browser;
        }

        public BrowserSession GetBrowser()
        {
            if (browser != null)
                return browser;

            var browserType = TestContext.Parameters["BROWSER"];
            switch (browserType)
            {
                case "CHROME":
                    var sessionConfigurationForChrome = new SessionConfiguration()
                    {
                        Driver = typeof(CustomChromeWebDriver),
                        Browser = Coypu.Drivers.Browser.Chrome,
                        AppHost = "https://specflow.org/", // whatever url you want
                        Timeout = TimeSpan.FromSeconds(2)
                    };
                    browser = new BrowserSession(sessionConfigurationForChrome);
                    browser.MaximiseWindow();
                    break;

                case "CHROMEHEADLESS":
                    var sessionConfigurationForChromeHeadless = new SessionConfiguration()
                    {
                        Driver = typeof(CustomChromeHeadlessWebDriver),
                        Browser = Coypu.Drivers.Browser.Chrome,
                        AppHost = "https://specflow.org/", // whatever url you want
                        Timeout = TimeSpan.FromSeconds(2)
                    };
                    browser = new BrowserSession(sessionConfigurationForChromeHeadless);
                    browser.ResizeTo(1124, 850);
                    break;

                case "FIREFOX":
                    var sessionConfigurationForFirefox = new SessionConfiguration()
                    {
                        Driver = typeof(CustomFirefoxWebDriver),
                        Browser = Coypu.Drivers.Browser.Firefox,
                        AppHost = "https://specflow.org/", // whatever url you want
                        Timeout = TimeSpan.FromSeconds(2)
                    };
                    browser = new BrowserSession(sessionConfigurationForFirefox);
                    browser.ResizeTo(1124, 850);
                    break;

                case "FIREFOXHEADLESS":
                    var sessionConfigurationForFirefoxHeadless = new SessionConfiguration()
                    {
                        Driver = typeof(CustomFirefoxHeadlessWebDriver),
                        Browser = Coypu.Drivers.Browser.Firefox,
                        AppHost = "https://specflow.org/", // whatever url you want
                        Timeout = TimeSpan.FromSeconds(2)
                    };
                    browser = new BrowserSession(sessionConfigurationForFirefoxHeadless);
                    browser.ResizeTo(1124, 850);
                    break;

                case "INTERNETEXPLORER":
                    var sessionConfigurationForInternetExplorer = new SessionConfiguration()
                    {
                        Driver = typeof(CustomInternetExplorerWebDriver),
                        Browser = Coypu.Drivers.Browser.InternetExplorer,
                        AppHost = "https://specflow.org/", // whatever url you want
                        Timeout = TimeSpan.FromSeconds(2)
                    };
                    browser = new BrowserSession(sessionConfigurationForInternetExplorer);
                    browser.ResizeTo(1124, 850);
                    break;

                default:
                    var defaultSessionConfiguration = new SessionConfiguration()
                    {
                        Driver = typeof(CustomChromeWebDriver),
                        Browser = Coypu.Drivers.Browser.Chrome,
                        AppHost = "https://specflow.org/", // whatever url you want
                        Timeout = TimeSpan.FromSeconds(2)
                    };
                    browser = new BrowserSession(defaultSessionConfiguration);
                    browser.ResizeTo(1124, 850);
                    break;
            }
            return browser;
        }

        public void CloseBrowser()
        {
            browser.Dispose();
        }

    }
}
