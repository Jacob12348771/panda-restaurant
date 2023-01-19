using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace AutomatedTests
{
    public class DashboardTests : IDisposable
    {
        private readonly IWebDriver _driver;
        public DashboardTests() => _driver = new ChromeDriver();

        [Fact]
        public void Home_Page_Loads()
        {
            // Navigates to the homepage of our app
            _driver.Navigate()
                .GoToUrl("https://localhost:2345");
            // Checks that the page is the home page
            Assert.Equal("Dashboard - PandaRestaurant", _driver.Title);
            // Assert.Contains("Dashboard", _driver.PageSource);

        }

        [Fact]
        public void Tables_Occupied_Card_Navigates_To_Tables_Page()
        {
            // Navigate to the Dashboard of our app
            _driver.Navigate()
          .GoToUrl("https://localhost:2345");
            // Finds and Clicks on Tables Occupied Card
            _driver.FindElement(By.Id("tables-occupied-card"))
        .Click();
            // Checks that we have navigated to the tables page
            Assert.Equal("Tables - PandaRestaurant", _driver.Title);
            Assert.Equal("https://localhost:2345/Tables", _driver.Url);
        }


        [Fact]
        public void Tables_Free_Card_Navigates_To_Tables_Page()
        {
            // Navigate to the Dashboard of our app
            _driver.Navigate()
          .GoToUrl("https://localhost:2345");
            // Finds and Clicks on Tables Free Card
            _driver.FindElement(By.Id("tables-free-card"))
        .Click();
            // Checks that we have navigated to the tables page
            Assert.Equal("Tables - PandaRestaurant", _driver.Title);
            Assert.Equal("https://localhost:2345/Tables", _driver.Url);
        }

        [Fact]
        public void Orders_Active_Card_Navigates_To_Orders_Page()
        {
            // Navigate to the Dashboard of our app
            _driver.Navigate()
          .GoToUrl("https://localhost:2345");
            // Finds and Clicks on Orders Active Card
            _driver.FindElement(By.Id("orders-active-card"))
        .Click();
            // Checks that we have navigated to the orders page
            Assert.Equal("Orders - PandaRestaurant", _driver.Title);
            Assert.Equal("https://localhost:2345/Orders", _driver.Url);
        }

        [Fact]
        public void Orders_Table_Rows_Navigate_To_Correct_Order_Detail_Page()
        {
            // Navigate back to the dashboard of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345");

            int numOfOrders = _driver.FindElements(By.ClassName("order-table-row")).Count;

            // For each order in the order table
            for (int i = 0; i < numOfOrders; i++)
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

                // Clicks on the row in the table 
                IWebElement tableRow = _driver.FindElement(By.Id("order-" + (i + 1).ToString()));
                new Actions(_driver)
                .MoveToElement(tableRow)
                .Perform();
                new Actions(_driver)
                .MoveToElement(tableRow)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct details page
                Assert.Equal("Order Details - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Orders/Details?id=" + (i + 1).ToString(), _driver.Url);

                // Navigate back to the dashboard of our app (except for last run
                if (i != numOfOrders)
                {
                    _driver.Navigate().Back();
                }
           

            }

        }







        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

    }
}