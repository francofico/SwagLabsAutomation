using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SwagLabsAutomation.Pages
{
    public class ProductsPage : BasePage
    {

        private By addToCartButtons = By.XPath("//*[contains(text(), 'Add to cart')]");
        private By shoppingCartIcon = By.Id("shopping_cart_container");
        private By shoppingCartProductAmount = By.ClassName("shopping_cart_badge");
        private By sortFromLowestToHighestPriceLocator = By.XPath("//*[@class='product_sort_container']/option[@value='lohi']");
        private By itemPricesLocator = By.ClassName("inventory_item_price");
        
        private ReadOnlyCollection<IWebElement>? addToCartButtonList;

        public ProductsPage(WebDriver driver) : base(driver)
        { }


        public void ClickRandomAddToCartButton()
        {
            Random random = new Random();

            addToCartButtonList = driver.FindElements(addToCartButtons);

            int buttonValue = random.Next(addToCartButtonList.Count);
            addToCartButtonList[buttonValue].Click();

        }

        public string GetProductsAmountOnShoppingCart()
        {
            return driver.FindElement(shoppingCartProductAmount).Text;
        }

        public ShoppingcartPage ClickShoppingCartIcon()
        {
            driver.FindElement(shoppingCartIcon).Click();
            return new ShoppingcartPage(driver);
        }

        public ProductsPage SortFromLowestToHighestPrice() 
        {
            driver.FindElement(sortFromLowestToHighestPriceLocator).Click();

            return this;
        }

        public List<double> GetItemPrices()
        {
            return driver.FindElements(itemPricesLocator)
                         .Select(x => x.Text.Replace("$", String.Empty))
                         .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
                         .ToList();
        }
    }
}
