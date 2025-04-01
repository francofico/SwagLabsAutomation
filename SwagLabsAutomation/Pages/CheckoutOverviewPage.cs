using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using static System.Net.Mime.MediaTypeNames;

namespace SwagLabsAutomation.Pages
{
    public class CheckoutOverviewPage : BasePage
    {
        private By itemsPriceLocator = By.ClassName("inventory_item_price");
        private By itemTotalLocator = By.ClassName("summary_subtotal_label"); 
        private By taxLocator = By.ClassName("summary_tax_label");
        private By totalLocator = By.ClassName("summary_total_label");
        private By finishButtonLocator = By.Id("finish");
        private By completeMessageLocator = By.Id("checkout_complete_container");


        public CheckoutOverviewPage(WebDriver driver) : base(driver) 
        {
            
        }

        public double GetItemPriceSum()
        {
            double amount = 0.00;

            foreach (IWebElement item in driver.FindElements(itemsPriceLocator))
            {
                string text = item.Text.Replace("$", string.Empty);
                amount += double.Parse(text, CultureInfo.InvariantCulture);
            }

            return amount;
        }
        public double GetTaxValue() 
        {
            return double.Parse(driver.FindElement(taxLocator).Text.Replace("Tax: $", string.Empty), CultureInfo.InvariantCulture); 
        }

        public double GetTotalPrice()
        {
            return double.Parse(driver.FindElement(totalLocator).Text.Replace("Total: $", string.Empty), CultureInfo.InvariantCulture);
        }

        public void ClickFinishButton() 
        {
            driver.FindElement(finishButtonLocator).Click();
        }

        public bool IsCompleteMessageDisplayed()
        {
            return driver.FindElement(completeMessageLocator).Displayed;
        }

    }
}
