using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using System.Threading;

namespace SeleniumTests
{
    [TestFixture]
    public class CheckStage
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;     
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            baseURL = "https://www.testweb.com/pp" +
                "/";
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheCheckStageTest()
        {
            driver.Navigate().GoToUrl("https://www.testweb.com/pp");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("inputPassword")).Clear();
            driver.FindElement(By.Id("inputUsername")).Clear();
            driver.FindElement(By.Id("inputUsername")).SendKeys("mail@server.com");
            driver.FindElement(By.Id("inputPassword")).Clear();
            driver.FindElement(By.Id("inputPassword")).SendKeys("dadadadadada");
            driver.FindElement(By.Id("inputPassword")).SendKeys(Keys.Enter);
            Thread.Sleep(10000);
            driver.FindElement(By.Id("inputSearch")).Clear();
            driver.FindElement(By.Id("inputSearch")).SendKeys("3999");
            driver.FindElement(By.XPath("(//button[@type='button'])[2]")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//td[8]")).Click();
            driver.FindElement(By.XPath("//div[3]/div/button/i")).Click();
            driver.FindElement(By.XPath("//li[7]/a/span")).Click();
            Assert.AreNotEqual("Never", driver.FindElement(By.XPath("//td[8]/span")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
