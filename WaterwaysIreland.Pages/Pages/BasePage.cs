using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WaterwaysIreland.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;

        protected abstract string Url { get; }

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public bool IsCurrentPage()
        {
            return Driver.Url == Url;
        }
    }
}
