using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Testes.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using Testes.Testes;
using Testes;

namespace SeleniumTests.Testes.Binario
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Binario
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private Utils utils;

        [SetUp]
        public void SetupTest()
        {
            new Driver().SetUp(ref driver, ref utils, ref baseURL);
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            Driver.TearDown(ref driver);
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheTest()
        {            
            Assert.IsTrue(true);
        }
    }
}
