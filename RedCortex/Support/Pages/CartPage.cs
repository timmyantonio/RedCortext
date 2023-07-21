using OpenQA.Selenium;
using RedCortex.Support.pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCortex.Support.pages
{
    public class CartPage : NavigationBar
    {
        private readonly IWebDriver _driver;
        public CartPage(IWebDriver driver) : base(driver) => _driver = driver;
        IWebElement GoToBasketButton => _driver.FindElement(By.PartialLinkText("Go to basket"));
        IWebElement ProceedToCheckoutButton => _driver.FindElement(By.Name("proceedToRetailCheckout"));
        
        public BasketPage ClickOnGoToBasketButton()
        {
            GoToBasketButton.Click();
            return new BasketPage(_driver);
        }

        public CartPage ClickOnProceedToCheckoutButton()
        {
            ProceedToCheckoutButton.Click();
            return this;
        }


    }
}
