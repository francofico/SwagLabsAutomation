using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SwagLabsAutomation.Tests
{
    public class TestBase
    {
        protected const string INVALID_USER = "invalid_user";
        protected const string VALID_USER = "standard_user";
        protected const string VALID_PASSWORD = "secret_sauce";

        protected const string INVENTORY_URL = "https://www.saucedemo.com/inventory.html";

        protected WebDriver driver;

        [SetUp]
        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(path + @"\drivers\");

            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            
            driver = new FirefoxDriver(service);

            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Dispose();
        }

    }
}
