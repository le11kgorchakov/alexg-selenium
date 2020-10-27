using OpenQA.Selenium.Chrome;
using SeleniumChallenge.WebDriver.Builders.Base;

namespace SeleniumChallenge.WebDriver.Builders
{
    public class ChromeDriverBuilder : WebDriverBuilder<ChromeDriver>
    {
        public override void Build(string binariesDirectory)
        {
            this.WebDriver = new ChromeDriver(binariesDirectory);
        }

        public override ChromeDriver GetResult()
        {
            return this.WebDriver;
        }
    }
}