using OpenQA.Selenium;
using SeleniumChallenge.WebDriver.Builders;
using SeleniumChallenge.WebDriver.Creators.Base;

namespace SeleniumChallenge.WebDriver.Creators
{
    public class FirefoxDriverCreator : WebDriverCreator
    {
        public override IWebDriver Create(WebDriverConstructor constructor)
        {
            var builder = new FirefoxDriverBuilder();
            constructor.Construct(builder);
            return builder.GetResult();
        }
    }
}
