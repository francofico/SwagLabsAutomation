using SwagLabsAutomation.Pages;


namespace SwagLabsAutomation.Tests
{
    public class LoginTests : TestBase
    {
        private LoginPage loginPage;

        [SetUp]
        public void BeforeTest()
        {
            loginPage = new LoginPage(driver);
        }
        
        [Test]
        public void ValidLogin()
        {
            loginPage.EnterCredentials(VALID_USER, VALID_PASSWORD);

            Assert.That(driver.Url, Is.EqualTo(INVENTORY_URL));
        }

        [Test]
        public void InvalidLogin()
        {
            loginPage.EnterCredentials(INVALID_USER, VALID_PASSWORD);

            Assert.That(loginPage.isErrorMessageDisplayed(), Is.True);
        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }
    }
}