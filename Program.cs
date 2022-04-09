using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium;

namespace Bot_Whatsapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://web.whatsapp.com/";
            List<string> contatos = new List<string>()
            {
                "Bot com C#"
            };
            ChromeDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            Thread.Sleep(5000);

            foreach (var contato in contatos)
            {
                var pesquisaEl = driver.FindElement(By.ClassName("_13NKt"));
                pesquisaEl.SendKeys(contato);

                Thread.Sleep(2000);

                //
                var contatoElemento = driver.FindElement(By.XPath($"//span[@title='{contato}']"));
                contatoElemento.Click();
                //

                Thread.Sleep(2000);

                var ChatElemento = driver.FindElement(By.ClassName("p3_M1"));
                ChatElemento.SendKeys("Olá, eu sou um robô.");


                var butonSendElemento = driver.FindElement(By.XPath($"//span[@data-icon='send']"));
                butonSendElemento.Click();

            }

        }
    }
}
