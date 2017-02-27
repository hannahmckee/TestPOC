using OpenQA.Selenium;

namespace WaterwaysIreland.Pages
{
    internal class ThingsToDoSubMenu : BaseComponent
    {
        private readonly IWebElement _element;

        private static readonly By WhatsOnLocator = By.XPath("//ul[contains(@class, \"submenu\")]//a[text()=\"What's On\"]");

        public IWebElement WhatsOn
        {
            get { return Driver.FindElement(WhatsOnLocator); }
        }

        public ThingsToDoSubMenu(IWebDriver driver, IWebElement element) : base(driver)
        {
            _element = element;
        }

        public void Click()
        {
            _element.Click();
        }
    }
}
