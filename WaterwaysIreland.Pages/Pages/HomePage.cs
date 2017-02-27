using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WaterwaysIreland.Pages.Utilities;

namespace WaterwaysIreland.Pages
{
    public class HomePage : BasePage
    {
        private const string LogoXPath = "//img[@alt='Waterways Ireland Logo']";
        private const string ShannonErneMapDestinationXPath = "//div[@class=\"mapHolder\"]//a[@data-map=\"shannon-erne\"]";
        private const string ShannonErneWaterwayXPath= "//div[contains(@class, \"waterwayholder\")]//a[@data-map=\"shannon-erne\"]";

        protected override string Url
        {
            get { return "http://staging.waterwaysireland.org/"; }
        }

        [FindsBy(How = How.XPath, Using = LogoXPath)]
        public IWebElement Logo;

        [FindsBy(How = How.XPath, Using = ShannonErneMapDestinationXPath)]
        public IWebElement ShannonErneMapDestination;

        [FindsBy(How = How.XPath, Using = ShannonErneWaterwayXPath)]
        public IWebElement ShannonErneWaterway;

        public HomePage(IWebDriver driver) : base(driver) { }

        public HomePage SelectWaterway(Waterway waterway)
        {
            IWebElement element = GetWaterway(waterway);
            element.Click();
            return this;
        }

        public bool MapWaterwayHasClass(Waterway waterway, string className)
        {
            IWebElement element = GetWaterwayOnMap(waterway);
            return element.HasCssClass(className);
        }

        private IWebElement GetWaterway(Waterway waterway)
        {
            IWebElement element;

            switch (waterway)
            {
                case Waterway.ShannonErne:
                    element = ShannonErneWaterway;
                    break;

                default:
                    return null;
            }

            return element;
        }

        private IWebElement GetWaterwayOnMap(Waterway waterway)
        {
            IWebElement element;

            switch (waterway)
            {
                case Waterway.ShannonErne:
                    element = ShannonErneMapDestination;
                    break;

                default:
                    return null;
            }

            return element;
        }
    }
}
