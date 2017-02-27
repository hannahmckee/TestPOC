using OpenQA.Selenium;

namespace WaterwaysIreland.Pages.Utilities
{
    public static class WebElementExtensions
    {
        public static bool HasCssClass(this IWebElement webElement, string className)
        {
            return webElement != null && webElement.GetAttribute("class").Contains(className);
        }

        public static bool IsDisplayed(this IWebElement webElement)
        {
            return webElement != null & webElement.Displayed;
        }
    }
}
