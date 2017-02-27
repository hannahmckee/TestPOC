using OpenQA.Selenium;

namespace WaterwaysIreland.Pages
{
    public class Menu : BaseComponent
    {
        private static readonly By AboutUsLocator = By.XPath("//a[@class='megaMenuTitle' and text()='About Us']");
        private static readonly By ThingsToDoLocator = By.XPath("//a[@class='megaMenuTitle' and text()='Things to Do']");

        private AboutUsSubMenu AboutUs
        {
            get
            {
                var webElement = Driver.FindElement(AboutUsLocator);
                return new AboutUsSubMenu(Driver, webElement);
            }
        }

        private ThingsToDoSubMenu ThingsToDo
        {
            get
            {
                var webElement = Driver.FindElement(ThingsToDoLocator);
                return new ThingsToDoSubMenu(Driver, webElement);
            }
        }

        public Menu(IWebDriver driver) : base(driver) { }

        public void NavigateToOurWork()
        {
            AboutUs.Click();
            AboutUs.OurWork.Click();
        }
    }
}
