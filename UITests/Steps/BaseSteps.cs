
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UITests.Pages;
using UITests.Utils;

namespace UITests.Steps
{
    [Binding]
    public class BaseSteps : BasePage
    {
        public BaseSteps(IWebDriver driver): base(driver)
        {

        }

        [When(@"I click on '(.*)' link")]
        public void WhenIClickOnLink(string field)
        {
            switch(field)
            {
                case "contact":
                    ClickEvent(_homePage.ContactLink);
                    break;
                case "facebook":
                    MoveAndClickElement(_contactPage.FacebookLink);
                    break;
            }
        }

        [Then(@"I navigated to '(.*)' page")]
        public void ThenINavigatedToPage(string title)
        {
            switch(title)
            {
                case "contact":
                    WaitForThePageTitle("Contact us | Crawford & Company | United Kingdom");
                    break;
                case "facebook":
                    WaitForThePageTitle("Crawford & Company - Home | Facebook");
                    break;
            }
        }

        [Then(@"validate the facebook url")]
        public void ThenValidateTheFacebookUrl()
        {
            string actualUrl = GetUrl();
            Assert.True(actualUrl.Equals("https://www.facebook.com/crawfordandco"), 
                $"Expecxted facebook url: '{"https://www.facebook.com/crawfordandco"}' is not same as actual url: '{actualUrl}'");
        }
    }
}
