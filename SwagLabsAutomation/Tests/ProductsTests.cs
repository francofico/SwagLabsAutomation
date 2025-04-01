using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SwagLabsAutomation.Pages;

namespace SwagLabsAutomation.Tests
{
    internal class ProductsTests : TestBase
    {
        ProductsPage productsPage;

        [SetUp]
        public void InitializeTest()
        { 
            LoginPage loginPage = new LoginPage(driver);
            productsPage = loginPage.EnterCredentials(VALID_USER, VALID_PASSWORD);
        }

        [Test]
        public void AddRandomItemToCartTest()
        {
            productsPage.ClickRandomAddToCartButton();

            string amount = productsPage.GetProductsAmountOnShoppingCart();
                
            Assert.That(amount, Is.EqualTo("1"));
        }

        [Test]
        public void AddMultipleItemsToCartTest()
        {
            Random random = new Random();
            int maxIndex  = random.Next(7);

            for(int i = 0; i < maxIndex; i++)
            {
                productsPage.ClickRandomAddToCartButton();
            }

            string amount = productsPage.GetProductsAmountOnShoppingCart();

            Assert.That(amount, Is.EqualTo(maxIndex.ToString()));

        }

        [Test]
        public void SortProductsTest()
        {
            productsPage.SortFromLowestToHighestPrice();

            List<double> prices = productsPage.GetItemPrices();

            Assert.That(prices, Is.Ordered.Ascending);
        }

        [Test]
        public void LogoutFromProductPageTest()
        {
            LoginPage loginPage = productsPage.LogOut();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));

            Assert.That(loginPage.IsLoginButtonDisplayed, Is.True);

        }

        [TearDown]
        public void CleanupTest() 
        {
            driver.Quit();
        }
    }
}
