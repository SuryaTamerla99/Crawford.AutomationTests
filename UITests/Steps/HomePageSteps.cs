using System.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UITests.Pages;
using UITests.Utils;

namespace UITests.Steps
{
    [Binding]
    public class HomePageSteps : BaseClass
    {
        private HomePage _homePage;
        public HomePageSteps(IWebDriver driver, HomePage homePage): base(driver)
        {
            _homePage = homePage;
        }

        [Given(@"I have navigated to crawco home page")]
        public void GivenIHaveNavigatedToCrawcoHomePage()
        {
            NavigateToPage(ConfigurationManager.AppSettings["CrawcoUrl"]);
            ClickEvent(_homePage.CookiesCloseButton);
        }
    }
}
