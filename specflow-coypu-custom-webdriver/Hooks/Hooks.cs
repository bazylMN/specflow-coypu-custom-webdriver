﻿using TechTalk.SpecFlow;
using specflow_coypu_custom_webdriver.WebDrivers;

namespace specflow_coypu_custom_webdriver.Hooks
{
    [Binding]
    public class Hooks
    {
        private BrowserSessionManager _browserSessionManager;

        public Hooks(BrowserSessionManager browserSessionManager)
        {
            _browserSessionManager = browserSessionManager;
        }

        [BeforeScenario]
        public void TestFixtureSetUp()
        {
            _browserSessionManager.GetBrowser();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _browserSessionManager.CloseBrowser();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            KillIEDriver.CloseIEBrowser();
        }

    }
}
