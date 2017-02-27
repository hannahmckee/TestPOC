using System;
using NUnit.Framework;
using WaterwaysIreland.Pages;
using WaterwaysIreland.Pages.Utilities;

namespace SeleniumExample
{
    [Category("What's On")]
    internal class WhatsOnTestFixture : BaseTestFixture
    {
        private WhatsOnPage _whatsOnPage;

        [SetUp]
        public void TestFixtureSetUp()
        {
            _whatsOnPage = new WhatsOnPage(Driver);
            _whatsOnPage.NavigateTo();
        }

        [Test]
        public void AllUpcomingEventsDisplayedByDefault()
        {
            // In here you could setUp SharePoint, to test for scenarios:
            // No Events
            // Hundreds of events
            // One event etc

            Assert.AreEqual(2, _whatsOnPage.EventDetails.Count);
        }

        [TestCase("Floating Cinema")]
        [TestCase("Mother's Day Cruise")]
        public void AnEventWithNameIsDisplayed(string eventName)
        {
            Assert.IsTrue(_whatsOnPage.ContainsEventNamed(eventName));
        }

        [Test]
        public void AllRelevantEventsAreDisplayedWhenFiltersAreApplied()
        {
            var whatsOnPage = new WhatsOnPage(Driver)
                .SelectLocation("Barrow Navigation")
                .SelectEventType("Community/Family Fun")
                .SelectEventStartDate(new DateTime(2015, 5, 2))
                .SelectEventEndDate(new DateTime(2015, 5, 3))
                .Filter();

            Assert.AreEqual(1, whatsOnPage.EventDetails.Count);
            Assert.IsTrue(whatsOnPage.ContainsEventNamed("Athy Dragon Boat Regatta"));
        }

        [Test]
        public void MessageShouldBeDisplayedWhenNoEventsAreAvailable()
        {
            var whatsOnPage = new WhatsOnPage(Driver)
                .SelectLocation("Barrow Navigation")
                .SelectEventType("Community/Family Fun")
                .SelectEventStartDate(new DateTime(2020, 5, 2))
                .Filter();

            Assert.AreEqual(0, whatsOnPage.EventDetails.Count);
            Assert.IsTrue(whatsOnPage.EventsNotFound.IsDisplayed());
        }
    }
}
