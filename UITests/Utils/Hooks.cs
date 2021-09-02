using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace UITests.Utils
{
    [Binding]
    public sealed class Hooks : DriverManager
    {
        private readonly ScenarioContext _scenarioContext;
        public Hooks(ObjectContainer objectContainer, ScenarioContext scenarioContext) : base(objectContainer)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            InitiateDriver(Constants.ChromeBrowser);
        }

        /// <summary>
        /// This method captures screenshot on test failure
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                if (_scenarioContext.TestError != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    Screenshot screenShot = ((ITakesScreenshot)Driver).GetScreenshot();
                    string title = _scenarioContext.ScenarioInfo.Title;
                    string screenShotName = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
                    Uri uri = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase);
                    string loadPath = Directory.GetParent(uri.LocalPath).FullName;
                    string screenShotDirectory = loadPath + "\\results\\screenshots\\";
                    if (!Directory.Exists(screenShotDirectory))
                    {
                        Directory.CreateDirectory(screenShotDirectory);
                        string screenShotFileName = screenShotDirectory + screenShotName + ".png";
                        screenShot.SaveAsFile(screenShotFileName);
                        string urlFile = Path.GetFullPath(screenShotFileName);
                        Console.WriteLine("Screenshot: {0}", new Uri(urlFile));
                        ReadOnlyCollection<LogEntry> logs = Driver.Manage().Logs.GetLog(LogType.Browser);
                        foreach (LogEntry log in logs)
                        {
                            stringBuilder.Append("\n" + log.Message);
                        }
                        TestContext.AddTestAttachment(urlFile, "ScreenShot");
                    }
                    else
                    {
                        string screenShotFileName = screenShotDirectory + screenShotName + ".png";
                        screenShot.SaveAsFile(screenShotFileName);
                        string urlFile = Path.GetFullPath(screenShotFileName);
                        Console.WriteLine("Screenshot: {0}", new Uri(urlFile));
                        ReadOnlyCollection<LogEntry> logs = Driver.Manage().Logs.GetLog(LogType.Browser);
                        foreach (LogEntry log in logs)
                        {
                            stringBuilder.Append("\n" + log.Message);
                        }
                        TestContext.AddTestAttachment(urlFile, "ScreenShot");
                    }
                    string logFileDirectory = loadPath + "\\results\\browserlogs\\";
                    Directory.CreateDirectory(logFileDirectory);
                    string logFileName = title + DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss") + ".txt";
                    File.AppendAllText(logFileDirectory + logFileName, stringBuilder.ToString());
                    TestContext.AddTestAttachment(logFileDirectory + logFileName, "BrowserLog");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                CleanUp();
            }
        }
    }
}
