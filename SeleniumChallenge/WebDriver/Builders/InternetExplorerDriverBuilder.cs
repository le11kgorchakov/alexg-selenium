using OpenQA.Selenium.IE;
using SeleniumChallenge.WebDriver.Builders.Base;

namespace SeleniumChallenge.WebDriver.Builders
{
    public class InternetExplorerDriverBuilder : WebDriverBuilder<InternetExplorerDriver>
    {
        public override void Build(string binariesDirectory)
        {
            //Unexpected error launching Internet Explorer.
            //Protected Mode settings are not the same for all zones. 
            //Enable Protected Mode must be set to the same value(enabled or disabled) for all zones

            this.WebDriver = new InternetExplorerDriver(binariesDirectory, new InternetExplorerOptions() { IntroduceInstabilityByIgnoringProtectedModeSettings = true });
        }

        public override InternetExplorerDriver GetResult()
        {
            return this.WebDriver;
        }
    }
}