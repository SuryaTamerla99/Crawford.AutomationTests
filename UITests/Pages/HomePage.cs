using OpenQA.Selenium;

namespace UITests.Pages
{
    public class HomePage
    {
        public By ContactLink => By.XPath("//a[text() = 'Contact']");
        public By CookiesCloseButton => By.XPath("//span[contains (@class, 'times-circle')]");
    }
}
