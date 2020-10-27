using OpenQA.Selenium;
using SeleniumChallenge.WebDriver.Builders;
using SeleniumChallenge.WebDriver.Creators.Base;

namespace SeleniumChallenge.WebDriver.Creators
{
    public class IEDriverCreator : WebDriverCreator
    {
        public override IWebDriver Create(WebDriverConstructor constructor)
        {
            var builder = new InternetExplorerDriverBuilder();
            constructor.Construct(builder);
            return builder.GetResult();
        }
    }
}