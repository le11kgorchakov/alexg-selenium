using OpenQA.Selenium.Firefox;
using SeleniumChallenge.WebDriver.Builders.Base;

namespace SeleniumChallenge.WebDriver.Builders
{
    public class FirefoxDriverBuilder : WebDriverBuilder<FirefoxDriver>
    {
        public override void Build(string binariesDirectory)
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions()
            {
                AcceptInsecureCertificates = true,
            };

            this.WebDriver = new FirefoxDriver(binariesDirectory, firefoxOptions);
        }

        public override FirefoxDriver GetResult()
        {
            return this.WebDriver;
        }
    }
}