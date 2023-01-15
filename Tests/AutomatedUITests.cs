namespace Tests
{
    public class AutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;
        public AutomatedUITests() => _driver = new ChromeDriver();

        [Fact]
        public void Home_Page_Loads()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:2345");
            Assert.Equal("Home page - PandaRestaurant", _driver.Title);
            Assert.Contains("Home page", _driver.PageSource);

        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

    }
}