using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace WaterwaysIreland.Pages
{
    public class WhatsOnPage:BasePage
    {
        private const string WhatsOnItemsXPath = "//div[@webpartid=\"00000000-0000-0000-0000-000000000000\"]//div[@class=\"row collapse\"]";
        private const string WhatsInItemXPath = "{0}//a[text()=\"{1}\"]";
        private const string EventStartDateDayXPath = "//select[contains(@class, \"day dateFrom\")]";
        private const string EventStartDateMonthXPath = "//select[contains(@class, \"month dateFrom\")]";
        private const string EventStartDateYearXPath = "//select[contains(@class, \"year dateFrom\")]";
        private const string EventEndDateDayXPath = "//select[contains(@class, \"day dateTo\")]";
        private const string EventEndDateMonthXPath = "//select[contains(@class, \"month dateTo\")]";
        private const string EventEndDateYearXPath = "//select[contains(@class, \"year dateTo\")]";
        private const string EventsNotFoundXPath= "//p[contains(text(), \"NO EVENTS HAVE BEEN FOUND\")]";

        private const string LocationId = "OptionsNavigationsDropDownList";
        private const string EventTypeId = "OptionsEventTypesDropDownList";
        private const string EventStartDateId = "dateFrom";

        private const string FilterButtonClass = "filterBtn";

        public static readonly By EventStartDateLocator = By.Id("dateFrom");

        protected override string Url
        {
            get { return "http://staging.waterwaysireland.org/whats-on"; }
        }

        [FindsBy(How = How.XPath, Using = WhatsOnItemsXPath)]
        public IList<IWebElement> EventDetails;

        [FindsBy(How=How.Id, Using=LocationId)]
        private IWebElement LocationDropDown;

        [FindsBy(How = How.Id, Using = EventTypeId)]
        private IWebElement EventTypeDropDown;

        [FindsBy(How = How.Id, Using = EventStartDateId)]
        private IWebElement EventSartDateDropDowns;

        [FindsBy(How = How.XPath, Using = EventStartDateDayXPath)]
        private IWebElement EventStartDateDayDropdown;

        [FindsBy(How = How.XPath, Using =  EventStartDateMonthXPath)]
        private IWebElement EventStartDateMonthDropdown;

        [FindsBy(How = How.XPath, Using = EventStartDateYearXPath)]
        private IWebElement EventStartDateYearDropdown;

        [FindsBy(How = How.XPath, Using = EventEndDateDayXPath)]
        private IWebElement EventEndDateDayDropdown;

        [FindsBy(How = How.XPath, Using = EventEndDateMonthXPath)]
        private IWebElement EventEndDateMonthDropdown;

        [FindsBy(How = How.XPath, Using = EventEndDateYearXPath)]
        private IWebElement EventEndDateYearDropdown;

        [FindsBy(How = How.ClassName, Using = FilterButtonClass)]
        private IWebElement FilterButton;

        [FindsBy(How = How.XPath, Using = EventsNotFoundXPath)]
        public IWebElement EventsNotFound;

        public WhatsOnPage(IWebDriver driver) : base(driver) { }

        public bool ContainsEventNamed(string eventName)
        {
            try
            {
                var eventElementXPath = string.Format(WhatsInItemXPath, WhatsOnItemsXPath, eventName);
                return Driver.FindElement(By.XPath(eventElementXPath)) != null;
            }
            catch
            {
                return false;
            }
        }

        public WhatsOnPage SelectLocation(string location)
        {
            new SelectElement(LocationDropDown).SelectByText(location);
            return this;
        }

        public WhatsOnPage SelectEventType(string eventType)
        {
            new SelectElement(EventTypeDropDown).SelectByText(eventType);
            return this;
        }

        public WhatsOnPage SelectEventStartDate(DateTime eventStartDate)
        {
            new SelectElement(EventStartDateDayDropdown).SelectByValue(eventStartDate.Day.ToString());
            new SelectElement(EventStartDateMonthDropdown).SelectByText(eventStartDate.ToString("MMM"));
            new SelectElement(EventStartDateYearDropdown).SelectByText(eventStartDate.Year.ToString());

            return this;
        }

        public WhatsOnPage SelectEventEndDate(DateTime eventEndDate)
        {
            new SelectElement(EventEndDateDayDropdown).SelectByText(eventEndDate.Day.ToString());
            new SelectElement(EventEndDateMonthDropdown).SelectByText(eventEndDate.ToString("MMM"));
            new SelectElement(EventEndDateYearDropdown).SelectByText(eventEndDate.Year.ToString());

            return this;
        }

        public WhatsOnPage Filter()
        {
            FilterButton.Click();
            return this;
        }
    }
}
