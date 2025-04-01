using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using SwagLabsAutomation.Pages;

namespace SwagLabsAutomation.Tests
{
    internal class ShoppingCartTests : TestBase
    {
        ShoppingcartPage shoppingcartPage;
        string amount;


        [SetUp]
        public void InitializeTest()
        {
            LoginPage loginPage = new LoginPage(driver);
            ProductsPage productsPage = loginPage.EnterCredentials(VALID_USER, VALID_PASSWORD);

            for (int index = 0; index < 3; index++)
            {
                productsPage.ClickRandomAddToCartButton();
            }

            amount = productsPage.GetProductsAmountOnShoppingCart();

            shoppingcartPage = productsPage.ClickShoppingCartIcon();
        }

        [Test]
        public void RemoveItemFromCartTest()
        { 
            Random random = new Random();

            int itemIndex = random.Next(Int32.Parse(amount));

            int currentItemAmount = shoppingcartPage.GetCurrentItemAmount();
            
            shoppingcartPage.RemoveProductFromCart(itemIndex);

            Assert.That(shoppingcartPage.GetCurrentItemAmount(), Is.EqualTo(currentItemAmount - 1));
        }

        [Test]
        public void SuccessfulCheckoutTest()
        { 
            CheckoutInfoPage checkoutInfoPage = shoppingcartPage.ClickCheckoutButton();
            checkoutInfoPage.EnterCheckoutInformation("Franco", "Perez", "1900");
            CheckoutOverviewPage checkoutOverviewPage = checkoutInfoPage.ClickContinueButton();
            
            double tax = checkoutOverviewPage.GetTaxValue();
            double itemSum = checkoutOverviewPage.GetItemPriceSum();
            double total = checkoutOverviewPage.GetTotalPrice();

            Assert.That(itemSum + tax, Is.EqualTo(total));

            checkoutOverviewPage.ClickFinishButton();

            Assert.That(checkoutOverviewPage.IsCompleteMessageDisplayed(), Is.EqualTo(true));
        }

        [Test]
        public void IncompleteDetailsTest()
        {
            CheckoutInfoPage checkoutInfoPage = shoppingcartPage.ClickCheckoutButton();
            checkoutInfoPage.EnterCheckoutInformation("Franco", "Perez", "");

            CheckoutOverviewPage checkoutOverviewPage = checkoutInfoPage.ClickContinueButton();

            Assert.That(checkoutInfoPage.isErrorMessageDisplayed(), Is.EqualTo(true));
            Assert.That(checkoutOverviewPage, Is.Null);
        }

        [TearDown]
        public void CleanupTest()
        {
            driver.Quit();
        }
    
    }
}
