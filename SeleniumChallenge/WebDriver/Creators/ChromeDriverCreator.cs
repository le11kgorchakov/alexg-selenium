using OpenQA.Selenium;
using SeleniumChallenge.WebDriver.Builders;
using SeleniumChallenge.WebDriver.Creators.Base;

namespace SeleniumChallenge.WebDriver.Creators
{
    public class ChromeDriverCreator : WebDriverCreator
    {
        public override IWebDriver Create(WebDriverConstructor constructor)
        {
            var chromeBuilder = new ChromeDriverBuilder();
            constructor.Construct(chromeBuilder);
            return chromeBuilder.GetResult();
        }
    }
}
