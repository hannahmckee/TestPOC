using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WaterwaysIreland.Pages;
using WaterwaysIreland.Pages.Utilities;

namespace SpecFlowExample.Steps
{
    [Binding]
    public sealed class WhatsOnPageSteps : BaseSteps
    {
        private WhatsOnPage _whatsOnPage;

        [Given("I have navigated to the Waterways Ireland What's On Page")]
        public void GivenIHaveNavigatedToTheHomePage()
        {
            _whatsOnPage = new WhatsOnPage(Driver);
            _whatsOnPage.NavigateTo();
        }

        [When("I select the location \"(.*)\"")]
        public void WhenISelectTheLocation(string eventLocation)
        {
            _whatsOnPage.SelectLocation(eventLocation);
        }

        [When("I select the Event Type \"(.*)\"")]
        public void WhenISelectTheEventType(string eventType)
        {
            _whatsOnPage.SelectEventType(eventType);
        }

        [When("I select the Event Start Date (.*)/(.*)/(.*)")]
        public void WhenISelectTheEventStartDate(int day, int month, int year)
        {
            var eventStartDate = new DateTime(year, month, day);
            _whatsOnPage.SelectEventStartDate(eventStartDate);
        }

        [When("I select the Event End Date (.*)/(.*)/(.*)")]
        public void WhenISelectTheEventEndDate(int day, int month, int year)
        {
            var eventEndDate = new DateTime(year, month, day);
            _whatsOnPage.SelectEventEndDate(eventEndDate);
        }

        [When("I filter the displayed events")]
        public void WhenIFilterTheDisplayedEvents()
        {
            _whatsOnPage.Filter();
        }

        [Then("(.*) upcoming events should be displayed")]
        public void ThenNumberOfEventsShouldBeDisplayed(int numberOfEvents)
        {
            Assert.AreEqual(numberOfEvents, _whatsOnPage.EventDetails.Count);
        }

        [Then("the following events should be displayed")]
        public void ThenTheFollowingEventsShouldBeDisplayed(Table expectedEvents)
        {
            foreach (var eventsRow in expectedEvents.Rows)
            {
                Assert.IsTrue(_whatsOnPage.ContainsEventNamed(eventsRow["EventName"]));
            }
        }

        [Then("No Events Found Message should be displayed")]
        public void ThenNoEventsFoundMessageShouldBeDisplayed()
        {
            Assert.IsTrue(_whatsOnPage.EventsNotFound.IsDisplayed());
        }
    }
}
