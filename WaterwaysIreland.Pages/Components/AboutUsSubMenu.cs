using OpenQA.Selenium;

namespace WaterwaysIreland.Pages
{
    internal class AboutUsSubMenu : BaseComponent
    {
        private IWebElement element;

        private static readonly By OurWorkLocator = By.XPath("//ul[contains(@class, \"submenu\")]//a[text()=\"Our Work\"]");

        public IWebElement OurWork
        {
            get { return Driver.FindElement(OurWorkLocator); }
        }

        public AboutUsSubMenu(IWebDriver driver, IWebElement webElement) : base(driver)
        {
            element = webElement;
        }

        public void Click()
        {
            element.Click();
        }
    }
}
