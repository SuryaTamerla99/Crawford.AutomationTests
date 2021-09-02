using OpenQA.Selenium;

namespace UITests.Pages
{
    public class ContactPage
    {
        public By FacebookLink => By.XPath("//a[text() = 'Facebook']");
    }
}
