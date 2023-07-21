using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCortex.Support.pages.Common
{
    public class NavigationBar
    {
        private readonly IWebDriver _driver;
        public NavigationBar(IWebDriver driver) => _driver = driver;

        IWebElement SearchBox => _driver.FindElement(By.Id("twotabsearchtextbox"));
        IWebElement SearchButton => _driver.FindElement(By.Id("nav-search-submit-button"));
        IWebElement Cart => _driver.FindElement(By.Id("nav-cart"));

        public NavigationBar ClickOnCart()
        {
            Cart.Click();
            return this;
        }

        public NavigationBar SearchItem(string itemName) {
            SearchBox.SendKeys(itemName);
            SearchButton.Click();
            return this;
        }
    
    }
}
