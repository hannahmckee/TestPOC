using NUnit.Framework;
using WaterwaysIreland.Pages;
using WaterwaysIreland.Pages.Utilities;

namespace SeleniumExample
{
    [Category("Home")]
    internal class HomePageTestFixture : BaseTestFixture
    {
        private HomePage _homePage;

        [SetUp]
        public void TestFixtureSetUp()
        {
            _homePage = new HomePage(Driver);
            _homePage.NavigateTo();
        }

        [Test]
        public void WaterwaysLogoShouldBeDisplayed()
        {
            Assert.IsTrue(_homePage.Logo.IsDisplayed());
        }

        [Test]
        public void MapDestinationsShouldMatchSelectedWaterway()
        {
            var homePage = new HomePage(Driver)
                .SelectWaterway(Waterway.ShannonErne);

            Assert.IsTrue(homePage.ShannonErneMapDestination.HasCssClass("active"));
        }
    }
}
