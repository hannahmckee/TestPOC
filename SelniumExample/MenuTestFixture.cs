using NUnit.Framework;
using WaterwaysIreland.Pages;

namespace SeleniumExample
{
    [Category("Menu")]
    internal class MenuTestFixture : BaseTestFixture
    {
        private HomePage _homePage;

        [SetUp]
        public void TestFixtureSetUp()
        {
            _homePage = new HomePage(Driver);
            _homePage.NavigateTo();
        }

        [Test]
        public void OurWorkPageCanBeNavigatedTo()
        {
            var ourWork = new OurWorkPage(Driver);
            var menu = new Menu(Driver);

            menu.NavigateToOurWork();
            Assert.IsTrue(ourWork.IsCurrentPage());
        }
    }
}
