using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SpecFlowExample.Steps
{
    [Binding]
    public abstract class BaseSteps
    {
        protected static IWebDriver Driver;

        protected BaseSteps()
        {
            // Open Chrome Driver
            Driver = new ChromeDriver(Properties.Settings.Default.SeleniumDriverDirectory);

            // Every time we try to access an element, 
            // try for X seconds before saying element can't be found
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [AfterTestRun]
        protected static void AfterTestRun()
        {
            // Close all open Driver windows
            Driver.Quit();
        }
    }
}
