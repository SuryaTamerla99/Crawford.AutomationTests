using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UITests.Utils
{
    public class BaseClass
    {
        private readonly IWebDriver _driver;
        public readonly WebDriverWait Wait;

        public BaseClass(IWebDriver driver)
        {
            _driver = driver;
            Wait = new WebDriverWait(this._driver, TimeSpan.FromSeconds(Constants.Timeout));
        }

        public void NavigateToPage(string pageUrl)
        {
            _driver.Navigate().GoToUrl(pageUrl);
        }

        public void WaitForPageToLoad()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Constants.PageLoadTimeout);
        }

        public void ClickEvent(By locator)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            SetHighlight(locator);
            _driver.FindElement(locator).Click();
        }

        public void EnterText(By locator, string text)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            SetHighlight(locator);
            _driver.FindElement(locator).Clear();
            _driver.FindElement(locator).SendKeys(text.Trim());
        }

        public void MoveAndClickElement(By locator)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            Actions builder = new Actions(_driver);
            builder.MoveToElement(_driver.FindElement(locator)).Click().Build().Perform();
        }

        public IWebElement GetElement(By locator)
        {
            return _driver.FindElement(locator);
        }

        public bool ScrollToView(By locator)
        {
            try
            {
                _driver.ExecuteJavaScript("arguments[0].scrollIntoView(true);", _driver.FindElement(locator));
                return true;
            }
            catch (Exception) { return false; }
        }

        public void SetHighlight(By locator)
        {
            string attributeValue = "border: 3px solid blue;";
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            try
            {
                Wait.Until(ExpectedConditions.ElementIsVisible(locator));
                IWebElement element = GetElement(locator);
                ScrollToView(locator);
                executor.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, attributeValue);
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Exception");
            }
        }

        public void WaitForThePageTitle(string title)
        {
            WaitForPageToLoad();
            Wait.Until(a => a.Title.Equals(title));
        }

        public string GetUrl()
        {
           return _driver.Url;
        }
    }
}
