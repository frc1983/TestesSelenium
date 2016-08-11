using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Testes.Helpers
{
    public class Utils
    {
        private IWebDriver driver;
        private bool acceptNextAlert = true;
        private string currentHandle;

        public Utils(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsElementPresent(By by)
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

        public bool IsAlertPresent()
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

        public string CloseAlertAndGetItsText()
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

        public static void PrintScreen(IWebDriver driver, string filename)
        {
            Screenshot sh = ((PhantomJSDriver)driver).GetScreenshot();
            sh.SaveAsFile(@"E:\" + filename + ".png", ImageFormat.Png);
        }

        public void ExecuteJavascriptClick(By selector)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            var element = wait.Until(dr => dr.FindElement(selector));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }

        public void WaitForElementIsPresent(By element)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 30) Assert.Fail("Timeout - WaitForElementIsPresent");
                try
                {
                    if (IsElementPresent(element)) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }

        public void SelectPopup()
        {
            currentHandle = driver.CurrentWindowHandle;
            driver.SwitchTo().Window(driver.WindowHandles.ToList().Last());
        }

        public void SelectMainWindow()
        {
            if (string.IsNullOrEmpty(currentHandle))
                driver.SwitchTo().DefaultContent();
            else
                driver.SwitchTo().Window(currentHandle);
        }

        public void SelectModalFrame()
        {
            WaitForElementIsPresent(By.XPath("//*[@id='fancybox-frame']"));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//*[@id='fancybox-frame']")));
        }
    }
}
