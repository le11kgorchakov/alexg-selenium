using OpenQA.Selenium;

namespace SeleniumChallenge.WebDriver.Creators.Base
{
    public abstract class WebDriverCreator : IWebDriverCreator
    {
        public abstract IWebDriver Create(WebDriverConstructor constructor);
    }
}
