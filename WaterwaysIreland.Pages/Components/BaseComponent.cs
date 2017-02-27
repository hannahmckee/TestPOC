using OpenQA.Selenium;

namespace WaterwaysIreland.Pages
{
    public abstract class BaseComponent
    {
        protected IWebDriver Driver;

        protected BaseComponent(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
