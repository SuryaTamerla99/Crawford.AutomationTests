using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace UITests.Utils
{
    public abstract class DriverManager
    {
        private readonly IObjectContainer _objectContainer;
        protected static IWebDriver Driver;

        protected DriverManager(ObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }
        protected void InitiateDriver(string browserType)
        {
            try
            {
                if (browserType != null)
                {
                    switch (browserType.ToUpper().Trim())
                    {
                        case "CHROME":
                            LoadChromeDriver();
                            break;

                        case "FIREFOX":
                            LoadFirefoxDriver();
                            break;

                        case "IE":
                            LoadIeDriver();
                            break;

                        default:
                            LoadChromeDriver();
                            break;
                    }
                }
                else { Console.WriteLine("Browser type is null, please send a valid browser name "); }
            }
            catch (Exception ex)
            { Console.WriteLine(ex); }
        }

        private void LoadChromeDriver()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Cookies.DeleteAllCookies();
            _objectContainer.RegisterInstanceAs<IWebDriver>(Driver);
            Driver.Manage().Window.Maximize();
        }

        private void LoadFirefoxDriver()
        {
            Driver = new FirefoxDriver();
            Driver.Manage().Cookies.DeleteAllCookies();
            _objectContainer.RegisterInstanceAs<IWebDriver>(Driver);
            Driver.Manage().Window.Maximize();
        }

        private void LoadIeDriver()
        {
            var driverService = InternetExplorerDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            var options = new InternetExplorerOptions
            {
                RequireWindowFocus = false,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true,
                EnableNativeEvents = false
            };

            Driver = new InternetExplorerDriver(driverService, options);
            _objectContainer.RegisterInstanceAs(Driver);
            Driver.Manage().Window.Maximize();
        }

        protected void CleanUp()
        {
            Driver.Quit();
        }
    }
}