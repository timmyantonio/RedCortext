using OpenQA.Selenium;
using RedCortex.Support.pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCortex.Support.pages
{
    public class BasketPage : NavigationBar
    {
        private readonly IWebDriver _driver;
        public BasketPage(IWebDriver driver) : base(driver) => _driver = driver;

        IWebElement ProceedToCheckoutButton => _driver.FindElement(By.Name("proceedToRetailCheckout"));
        public BasketPage ClickOnProceedToCheckoutButton()
        {
            ProceedToCheckoutButton.Click();
            return this;
        }

        public IWebElement GetItemElement(string itemName) => _driver.FindElement(By.XPath($"//span[text()='{itemName}']"));

    }
   
}
