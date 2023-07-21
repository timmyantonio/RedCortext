using OpenQA.Selenium;
using RedCortex.Support.pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCortex.Support.pages
{
    public class ItemDetailsPage : NavigationBar
    {

        private readonly IWebDriver _driver;

        public ItemDetailsPage(IWebDriver driver) : base(driver) => _driver = driver;
        IWebElement ProductTitleElement => _driver.FindElement(By.Id("productTitle"));
        IWebElement AddToBasketButton => _driver.FindElement(By.Id("add-to-cart-button"));
        IWebElement BuyNowButton => _driver.FindElement(By.Id("buy-now-button"));
        
        public string ProductTitle() => ProductTitleElement.Text;
        public CartPage ClickOnAddToBasketButton()
        {
            AddToBasketButton.Click();
            return new CartPage(_driver);
        }
        public ItemDetailsPage ClickOnBuyNowButton()
        {
            BuyNowButton.Click();
            return this;
        }

    }
}
