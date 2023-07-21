using OpenQA.Selenium;
using RedCortex.Support.pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCortex.Support.pages
{
    public class HomePage : NavigationBar
    {

        private readonly IWebDriver _driver;
        public HomePage(IWebDriver driver) : base(driver) => _driver = driver;
        public List<IWebElement> Items(string itemName) => _driver.FindElements(By.XPath($"//a/span[contains(text(),'{itemName}')]")).ToList();


    }
}
