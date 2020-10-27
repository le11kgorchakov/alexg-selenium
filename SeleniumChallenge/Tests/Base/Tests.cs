using OpenQA.Selenium;
using RestSharp;
using SeleniumChallenge.Tests.Base;
using System;
using Xunit;
using NUnit.Framework;

namespace SeleniumChallenge.Tests
{
    public class Tests : UITestBase
    {
        [Obsolete]
        [Fact]
        public void ClicksRunButtonAndCheckOutput()
        {
            var runButton = By.Id("run-button");
            WaitForPageUntilElementIsReady(runButton, 5, WebDriver);
            GetElementByLocator(runButton).Click();
            var output = WebDriver.FindElement(By.Id("output")).Text;
            Xunit.Assert.Equal("Hello World", output);
        }

        [Obsolete]
        [Fact]
        public void SelectsNuGetPackage()
        {
            string NuGetPackage = "3.12.0";
            var input = WebDriver.FindElement(By.XPath("//*[@id='CodeForm']/div[2]/div[2]/div[5]/div/div/input"));
            input.SendKeys(NuGetPackage);
            var nunit = By.XPath("/html/body/ul/li[1]/a");
            GetElementByLocator(nunit).Click();
            var version = By.XPath("/html/body/ul/li[1]/ul/li[1]/a");
            WaitForPageUntilElementIsReady(version, 5, WebDriver);
            GetElementByLocator(version).Click();
            RestClient client = new RestClient("https://dotnetfiddle.net/");
            RestRequest request = new RestRequest("NuGetPackage/GetPackageVersionInfo?packageId=NUnit&versionName=3.12.0.0", Method.GET);
            IRestResponse response = client.Execute(request);
            NUnit.Framework.Assert.That(response.StatusCode.ToString, Is.EqualTo("OK"));
        }
    }
}
