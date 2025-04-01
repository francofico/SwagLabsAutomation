using OpenQA.Selenium;

namespace SwagLabsAutomation.Pages
{
    public class CheckoutInfoPage : BasePage
    {
        private By firstNameFieldLocator    = By.Id("first-name");
        private By lastNameFieldLocator     = By.Id("last-name");
        private By postalCodeFieldLocator   = By.Id("postal-code");

        private By continueBtnLocator       = By.Id("continue");

        private By errorMessageLocator = By.ClassName("error-message-container");

        private IWebElement firstNameField;
        private IWebElement lastNameField;
        private IWebElement postalCodeField;

        public CheckoutInfoPage(WebDriver driver) : base(driver) 
        {
            firstNameField = driver.FindElement(firstNameFieldLocator);
            lastNameField = driver.FindElement(lastNameFieldLocator);
            postalCodeField = driver.FindElement(postalCodeFieldLocator);
        }

        public void EnterCheckoutInformation(string firstName, string lastName, string postalCode)
        {
            firstNameField.SendKeys(firstName);
            lastNameField.SendKeys(lastName);
            postalCodeField.SendKeys(postalCode);
        }

        public bool isErrorMessageDisplayed()
        {
            try
            {
                return driver.FindElement(errorMessageLocator).Displayed;
            }
            catch (NoSuchElementException exception)
            {
                return false;
            }
        }

        public CheckoutOverviewPage? ClickContinueButton()
        { 
            driver.FindElement(continueBtnLocator).Click();
            
            if (!isErrorMessageDisplayed())
            {
                return new CheckoutOverviewPage(driver);
            }
            else
            {
                return null;
            }
        }
    }
}
