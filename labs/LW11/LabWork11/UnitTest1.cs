using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Xunit;

namespace LabWork11
{
    public class SeleniumTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private const string Url = "file:///C:/Temp/ispp31/isrpo0202/labs/LW11/Site/LabWork10.html";
        
        public SeleniumTests()
        {
            var options = new ChromeOptions();
            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Fact]
        public void Test_5_2()
        {
            _driver.Navigate().GoToUrl(Url);

            IWebElement header = _driver.FindElement(By.Id("header"));
            Assert.True(header.Displayed, "Заголовок должен отображаться на странице");

            IWebElement test_image = _driver.FindElement(By.Id("test-image"));
            Assert.True(test_image.Displayed, "Изображение должно отображаться на странице");

            IWebElement header2 = _driver.FindElement(By.TagName("h2"));
            Assert.True(header2.Displayed, "Пoдзаголовок должен отображаться на странице");
        }

        public void Test_5_3()
        {
            _driver.Navigate().GoToUrl(Url);

            IWebElement search_text = _driver.FindElement(By.Id("search_text"));
            IWebElement submit_button = _driver.FindElement(By.Id("submit_button"));

            search_text.Clear();
            search_text.SendKeys("cdc");

            submit_button.Click();

            //_wait.Until(ExpectedConditions.UrlContains("https://www.google.com/search?q=cdc"));

            Assert.Contains("https://www.google.com/search?q=cdc", _driver.Url);
        }
        public void Dispose()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }


}
