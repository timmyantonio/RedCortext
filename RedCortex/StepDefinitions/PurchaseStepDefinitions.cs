using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RedCortex.Support;
using RedCortex.Support.pages;
using System;
using TechTalk.SpecFlow;

namespace RedCortex.StepDefinitions
{
    [Binding]
    public class PurchaseStepDefinitions
    {
        IWebDriver? _driver;
        WebDriverWait? wait;
        HomePage? homePage;
        ItemDetailsPage? itemDetailsPage;
        BasketPage? basketPage;
        string baseUrl = "https://www.amazon.co.uk/";
        string? selectedItemTitle;


       [BeforeScenario]
        public void Setup()
        {
            _driver = new ChromeDriver();
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            _driver.Url = baseUrl;
            _driver.Manage().Window.Maximize();
            _driver.FindElement(By.Id("sp-cc-rejectall-link")).Click();
        }

        [AfterScenario]
        public void Cleanup()
        {
            _driver?.Quit();
        }
    
        [Given(@"User is on homepage")]
        public void UserIsOnHomepage()
        {           
            homePage = new HomePage(_driver!);
        }

        [When(@"I seach for '([^']*)'")]
        public void SeachFor(string item)
        {
            homePage?.SearchItem(item);
        }

        [Then(@"I should see '([^']*)' and '([^']*)' generation Echo Dot speaker")]
        public void IShouldSeeGenerationEchoDotSpeakers(string item1, string item2)
        { 
            var echoDot3rdGenItems = homePage?.Items($"Echo Dot ({item1}");
            Assert.That(echoDot3rdGenItems?.Count(), Is.GreaterThan(0));
            
            var echoDot4thGenItems = homePage?.Items($"Echo Dot ({item2}");
            Assert.That(echoDot4thGenItems?.Count(), Is.GreaterThan(0));
           
        }


        [When(@"I select '([^']*)' Generation echo dot")]
        public void SelectGenerationEchoDot(string item)
        {
            var echoDot3rdGenItems = homePage?.Items($"Echo Dot ({item}");
            selectedItemTitle = echoDot3rdGenItems?.First().Text;
            wait?.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(echoDot3rdGenItems?.First())).Click();           
            itemDetailsPage = new ItemDetailsPage(_driver!);
        }

        [When(@"I add to cart")]
        public void AddToCart()
        {
            basketPage = itemDetailsPage?.ClickOnAddToBasketButton().ClickOnGoToBasketButton();
        }

        [Then(@"I should see the item added into the basket")]
        public void ItemAddedIntoTheBasket()
        {
            Assert.NotNull(basketPage?.GetItemElement(selectedItemTitle!));
        }
    }
}
