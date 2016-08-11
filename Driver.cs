using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using Testes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes
{
    public class Driver
    {
        public static String BaseUrl = "";//Url base do site a ser testado

        public PhantomJSDriver PhantomJS { get; set; }

        public Driver()
        {
            PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService("E:\\");//Caminho do phantomjs.exe
            service.IgnoreSslErrors = true;
            service.LoadImages = false;
            var options = new PhantomJSOptions();
            options.AddAdditionalCapability("phantomjs.page.settings.userAgent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:25.0) Gecko/20100101 Firefox/25.0");

            PhantomJS = new PhantomJSDriver(service, options);
            PhantomJS.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            PhantomJS.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
        }

        public void SetUp(ref IWebDriver driver, ref Helpers.Utils utils, ref string baseURL)
        {
            //ChromeDriver exibe o navegador e roda os testes
            //PhantomJSDriver NÂO exibe o navegador e roda os testes

            //driver = new ChromeDriver("E:\\");//Caminho do chromedriver.exe
            driver = PhantomJS;
            utils = new Utils(driver);
            baseURL = Driver.BaseUrl;
        }

        public static void TearDown(ref IWebDriver driver)
        {
            try
            {
                if (driver != null) driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
    }
}
