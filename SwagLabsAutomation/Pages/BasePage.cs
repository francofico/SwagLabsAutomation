using OpenQA.Selenium;

namespace SwagLabsAutomation.Pages
{
    public class BasePage(WebDriver driver)
    {
        protected WebDriver driver = driver;

        protected const string BASE_URL = "https://saucedemo.com";

        protected By burgerMenuLocator = By.Id("react-burger-menu-btn");
        protected By logoutLocator = By.Id("logout_sidebar_link");

        public LoginPage LogOut()
        { 
            driver.FindElement(burgerMenuLocator).Click();
            driver.FindElement(logoutLocator).Click();

            return new LoginPage(driver);
        }

    }
}
