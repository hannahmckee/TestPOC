using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumExample
{
    [TestFixture]
    public abstract class BaseTestFixture
    {
        protected static IWebDriver Driver;

        protected BaseTestFixture()
        {
            // Open Chrome Driver
            Driver  = new ChromeDriver(Properties.Settings.Default.SeleniumDriverDirectory);

            // Every time we try to access an element, 
            // try for X seconds before saying element can't be found
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [OneTimeTearDown]
        protected void BaseTestFixtureTearDown()
        {
            // Close all open Driver windows
            Driver.Quit();
        }
    }
}
