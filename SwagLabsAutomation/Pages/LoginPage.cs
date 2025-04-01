using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SwagLabsAutomation.Pages
{
    public class LoginPage : BasePage
    {
        private By userFieldLocator             = By.Id("user-name");
        private By passwordFieldLocator         = By.Id("password");
        private By loginButtonLocator           = By.Id("login-button");

        private By wrongCredentialsErrorMessage = By.ClassName("error-message-container");

        private IWebElement userField;
        private IWebElement passwordField;
        private IWebElement loginButton;

        public LoginPage(WebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl(BASE_URL);
            userField     = driver.FindElement(userFieldLocator);
            passwordField = driver.FindElement(passwordFieldLocator);
            loginButton   = driver.FindElement(loginButtonLocator);
        }

        public ProductsPage? EnterCredentials(string username, string password)
        {
            userField.SendKeys(username);
            passwordField.SendKeys(password);

            loginButton.Click();

            if (!isErrorMessageDisplayed())
            {
                return new ProductsPage(driver);
            }
            else
            {
                return null;
            }
        }

        public bool isErrorMessageDisplayed()
        {
            try
            {
                return driver.FindElement(wrongCredentialsErrorMessage).Displayed;
            }
            catch (NoSuchElementException exception)
            {
                return false;
            }
        }

        public bool IsLoginButtonDisplayed()
        {
            try
            {
                return driver.FindElement(loginButtonLocator).Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}
