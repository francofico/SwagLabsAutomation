using OpenQA.Selenium;

namespace SwagLabsAutomation.Pages
{
    public class ShoppingcartPage : BasePage
    {
        private By cartItem         = By.ClassName("cart_item");
        private By checkoutButtonId = By.Id("checkout");
        private By removeButtons    = By.XPath("//*[contains(text(), 'Remove')]");

        private IWebElement checkoutButton;

        int itemAmount;

        public ShoppingcartPage(WebDriver driver) : base(driver)
        {
            itemAmount      = driver.FindElements(cartItem).Count();
            checkoutButton  = driver.FindElement(checkoutButtonId);
        }

        public int GetCurrentItemAmount()
        { 
            return itemAmount;
        }

        public void RemoveProductFromCart(int productIndex)
        {
            driver.FindElements(removeButtons)[productIndex].Click();
            itemAmount = driver.FindElements(cartItem).Count();
        }

        public CheckoutInfoPage ClickCheckoutButton()
        { 
            checkoutButton.Click();
            return new CheckoutInfoPage(driver);
        }
    }
}
