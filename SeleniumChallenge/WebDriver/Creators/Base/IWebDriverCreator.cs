using OpenQA.Selenium;

namespace SeleniumChallenge.WebDriver.Creators.Base
{
    public interface IWebDriverCreator
    {
        IWebDriver Create(WebDriverConstructor webDriverConstructor);
    }
}