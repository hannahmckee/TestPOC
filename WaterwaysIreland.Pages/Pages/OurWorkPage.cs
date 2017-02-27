using OpenQA.Selenium;

namespace WaterwaysIreland.Pages
{
    public class OurWorkPage : BasePage
    {
        protected override string Url
        {
            get { return "http://staging.waterwaysireland.org/about-us/our-work"; }
        }

        public OurWorkPage(IWebDriver driver) : base(driver) { }
    }
}
