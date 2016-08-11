using OpenQA.Selenium;
using Testes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Testes.Testes
{
    //Métodos de uso genérico para execução dos testes do projeto
    public class Generics
    {
        public static void Login(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Driver.BaseUrl + "/Portal/Logon.aspx");
            driver.FindElement(By.Id("txtLogin")).Clear();
            driver.FindElement(By.Id("txtLogin")).SendKeys("07447065641");
            driver.FindElement(By.Id("txtSenha")).Clear();
            driver.FindElement(By.Id("txtSenha")).SendKeys("Caminha1988");
            driver.FindElement(By.Id("aBt")).Click();
        }

        public static void Logoff(Utils utils, IWebDriver driver)
        {
            utils.ExecuteJavascriptClick(By.CssSelector("strong"));
            utils.ExecuteJavascriptClick(By.Id("lbtSair"));
        }
    }
}
