using OpenQA.Selenium;
using UITests.Utils;

namespace UITests.Pages
{
    public class BasePage : BaseClass
    {
        public ContactPage _contactPage;
        public HomePage _homePage;
        public BasePage(IWebDriver driver) : base(driver)
        {
            _contactPage = new ContactPage();
            _homePage = new HomePage();
        }
    }
}
