using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TryAgain.PageObject
{
    public class DefaultActions
    {

        IDictionary<string, string> xpaths = new Dictionary<string, string>();

        IWebDriver driver;

        private static DefaultActions instance = null;

        public static DefaultActions getInstance()
        {

            if (instance == null)
            {
                instance = new DefaultActions();
            }

            return instance;
        }

        private DefaultActions()
        {
            driver = new ChromeDriver();
            xpaths.Add("Full name", "//input[@id='userName']");
            xpaths.Add("Email", "//input[@id='userEmail']");
            xpaths.Add("Submit", "//button[@id='submit']");
        }

        public void navigateToUrl(String url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        public bool verifyPageTitle(String expectedTitle)
        {
            return driver.Title.Contains(expectedTitle);
        }

        public IWebElement waitForElement(String xpathLabel)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpaths[xpathLabel])));
            return element;
        }

        public bool verifyTextPresentInPage(string expectedText)
        {
            try
            {
                return driver.FindElement(By.XPath(String.Format("//p[contains(.,'{0}')]", expectedText))).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void sendKeysToElement(String text, String xpathLabel)
        {
            IWebElement element = waitForElement(xpathLabel);
            element.Clear();
            element.SendKeys(text);
        }

        public void pressElement(String xpathLabel)
        {
            IWebElement element = waitForElement(xpathLabel);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/a")).Click();
            
            element.Click();

        }

        public bool verifyElementHasTextInput(String text, String xpathLabel)
        {
            return driver.FindElement(By.XPath(xpaths[xpathLabel])).GetAttribute("value").Equals(text);
        }

        public void quitDriver()
        {
            //driver.Quit();
        }

    }
}
