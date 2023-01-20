using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace AutomatedTests
{
    public class OrdersTests : IDisposable
    {
        private readonly IWebDriver _driver;
        public OrdersTests() => _driver = new ChromeDriver();

        [Fact]
        public void Orders_Page_Loads()
        {
            // Navigates to the Orders page of our app
            _driver.Navigate()
                .GoToUrl("https://localhost:2345/Orders");
            // Checks that the page is the Orders page
            Assert.Equal("Orders - PandaRestaurant", _driver.Title);

        }

        [Fact]
        public void Orders_Table_Rows_Navigate_To_Correct_Orders_Details_Page()
        {
            // Navigate to the Orders page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345");

            int numOfOrders = _driver.FindElements(By.ClassName("order-table-row")).Count;

            // For each order in the order table
            for (int i = 0; i < numOfOrders; i++)
            {

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


        [Fact]
        public void Order_Create_Button_Navigates_To_The_Create_Page()
        {
            // Navigate to the Orders page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/Orders");

                // Clicks on the create order button
                IWebElement create = _driver.FindElement(By.Id("create"));
                new Actions(_driver)
                .MoveToElement(create)
                .Perform();
                new Actions(_driver)
                .MoveToElement(create)
                .Click()
                .Perform();

                // Checks that we have navigated to the create order page
                Assert.Equal("Create Order - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Orders/Create", _driver.Url);


        }


        [Fact]
        public void Orders_Edit_Buttons_Navigate_To_Correct_Orders_Edit_Page()
        {
            // Navigate to the Orders page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/Orders");

            int numOfOrders = _driver.FindElements(By.ClassName("order-table-row")).Count;

            // For each order in the order table
            for (int i = 0; i < numOfOrders; i++)
            {

                // Clicks on the edit button for this row 
                IWebElement edit = _driver.FindElement(By.CssSelector("#order-" + (i + 1).ToString() + " .edit"));
                new Actions(_driver)
                .MoveToElement(edit)
                .Perform();
                new Actions(_driver)
                .MoveToElement(edit)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct edit page
                Assert.Equal("Edit Order - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Orders/Edit?id=" + (i + 1).ToString(), _driver.Url);

                // Navigate back to the dashboard of our app (except for last run
                if (i != numOfOrders)
                {
                    _driver.Navigate().Back();
                }

            }

        }

        [Fact]
        public void Orders_Delete_Buttons_Navigate_To_Correct_Orders_Delete_Page()
        {
            // Navigate to the Orders page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/Orders");

            int numOfOrders = _driver.FindElements(By.ClassName("order-table-row")).Count;

            // For each order in the order table
            for (int i = 0; i < numOfOrders; i++)
            {

                // Clicks on the delete button for this row 
                IWebElement delete = _driver.FindElement(By.CssSelector("#order-" + (i + 1).ToString() + " .delete"));
                new Actions(_driver)
                .MoveToElement(delete)
                .Perform();
                new Actions(_driver)
                .MoveToElement(delete)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct delete page
                Assert.Equal("Delete Order - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Orders/Delete?id=" + (i + 1).ToString(), _driver.Url);

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