using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumChallenge.WebDriver.Creators.Base;
using SeleniumChallenge.WebDriver;
using SeleniumChallenge.WebDriver.Creators;
using Microsoft.Extensions.Configuration;
using SeleniumChallenge.Extensions.Configuration;

namespace SeleniumChallenge.Tests.Base
{
    /// <summary>
    /// Base class for all UI tests.
    /// </summary>
    public abstract class UITestBase : IDisposable
    {
        protected IConfiguration Configuration { get; }

        protected IWebDriver WebDriver
        {
            get;
            private set;
        }

        public UITestBase()
        {
            this.Configuration = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

            Setup();
            this.WebDriver.Navigate().GoToUrl("https://dotnetfiddle.net");
        }

        public void Dispose()
        {
            if (this.WebDriver != null)
            {
                this.WebDriver.Quit();
                this.WebDriver = null;
            }
        }

        public void Setup()
        {
            string binariesDir = Environment.CurrentDirectory;

#if IE
            IWebDriverCreator creator = new IEDriverCreator();
#endif

#if FIREFOX
            IWebDriverCreator creator = new FirefoxDriverCreator();
#endif

#if CHROME
            IWebDriverCreator creator = new ChromeDriverCreator();
#endif

            WebDriverConstructor webDriverConstructor = new WebDriverConstructor(binariesDir);
            this.WebDriver = creator.Create(webDriverConstructor);

            if (this.WebDriver == null)
            {
                throw new NullReferenceException(
                    "Please run the tests using one of the valid build " +
                    "configurations geared towards a particular browser. " +
                    "See above for details");
            }

            // Set any common/global settings against the WebDriver instance.
            this.WebDriver.Manage().Timeouts().ImplicitWait = this.Configuration.GetImplicitWait();

            this.WebDriver.Manage().Window.Maximize();
        }
        [Obsolete]
        public IWebElement WaitForPageUntilElementIsReady(By locator, int timeInSeconds, IWebDriver driver)

        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        protected IWebElement GetElementByLocator(By locator)
        {
            return WebDriver.FindElement(locator);
        }


    }
}