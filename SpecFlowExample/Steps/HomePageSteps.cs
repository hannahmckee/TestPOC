using NUnit.Framework;
using SpecFlowExample.Utilities;
using TechTalk.SpecFlow;
using WaterwaysIreland.Pages;
using WaterwaysIreland.Pages.Utilities;

namespace SpecFlowExample.Steps
{
    [Binding]
    public sealed class HomePageSteps : BaseSteps
    {
        private HomePage _homePage;

        [Given("I have navigated to the Waterways Ireland Home Page")]
        public void GivenIHaveNavigatedToTheHomePage()
        {
            _homePage = new HomePage(Driver);
            _homePage.NavigateTo();
        }

        [When("I select the waterway named \"(.*)\"")]
        public void WhenISelectTheWaterwayNamed(string waterwayName)
        {
            Waterway waterwayToSelect = EnumUtilities.GetValueFromDescription<Waterway>(waterwayName);

            _homePage = new HomePage(Driver)
                .SelectWaterway(waterwayToSelect);

            Assert.IsTrue(_homePage.MapWaterwayHasClass(waterwayToSelect, "active"));
        }

        [Then(@"the logo should be displayed")]
        public void ThenTheLogoShouldBeDisplayed()
        {
            Assert.IsTrue(_homePage.Logo.IsDisplayed());
        }

        [Then("the map destination for the waterway named \"(.*)\" should have the css class \"(.*)\"")]
        public void ThenTheMapDestinationShouldHaveAppliedClass(string waterwayName, string className)
        {
            Waterway waterway = EnumUtilities.GetValueFromDescription<Waterway>(waterwayName);
            Assert.IsTrue(_homePage.MapWaterwayHasClass(waterway, className));
        }
    }
}
