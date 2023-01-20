using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace AutomatedTests
{
    public class CustomersTests : IDisposable
    {
        private readonly IWebDriver _driver;
        public CustomersTests() => _driver = new ChromeDriver();

        [Fact]
        public void Customers_Page_Loads()
        {
            // Navigates to the Customers page of our app
            _driver.Navigate()
                .GoToUrl("https://localhost:2345/Customers");
            // Checks that the page is the Customers page
            Assert.Equal("Customers - PandaRestaurant", _driver.Title);

        }

        [Fact]
        public void Customers_Customer_Rows_Navigate_To_Correct_Customers_Details_Page()
        {
            // Navigate to the Customers page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345");

            int numOfCustomers = _driver.FindElements(By.ClassName("customer-customer-row")).Count;

            // For each customer in the customer customer
            for (int i = 0; i < numOfCustomers; i++)
            {

                // Clicks on the row in the customer 
                IWebElement customerRow = _driver.FindElement(By.Id("customer-" + (i + 1).ToString()));
                new Actions(_driver)
                .MoveToElement(customerRow)
                .Perform();
                new Actions(_driver)
                .MoveToElement(customerRow)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct details page
                Assert.Equal("Customer Details - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Customers/Details?id=" + (i + 1).ToString(), _driver.Url);

                // Navigate back to the dashboard of our app (except for last run
                if (i != numOfCustomers)
                {
                    _driver.Navigate().Back();
                }

            }

        }


        [Fact]
        public void Customer_Create_Button_Navigates_To_The_Create_Page()
        {
            // Navigate to the Customers page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/Customers");

                // Clicks on the create customer button
                IWebElement create = _driver.FindElement(By.Id("create"));
                new Actions(_driver)
                .MoveToElement(create)
                .Perform();
                new Actions(_driver)
                .MoveToElement(create)
                .Click()
                .Perform();

                // Checks that we have navigated to the create customer page
                Assert.Equal("Create Customer - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Customers/Create", _driver.Url);


        }


        [Fact]
        public void Customers_Edit_Buttons_Navigate_To_Correct_Customers_Edit_Page()
        {
            // Navigate to the Customers page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/Customers");

            int numOfCustomers = _driver.FindElements(By.ClassName("customer-customer-row")).Count;

            // For each customer in the customer customer
            for (int i = 0; i < numOfCustomers; i++)
            {

                // Clicks on the edit button for this row 
                IWebElement edit = _driver.FindElement(By.CssSelector("#customer-" + (i + 1).ToString() + " .edit"));
                new Actions(_driver)
                .MoveToElement(edit)
                .Perform();
                new Actions(_driver)
                .MoveToElement(edit)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct edit page
                Assert.Equal("Edit Customer - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Customers/Edit?id=" + (i + 1).ToString(), _driver.Url);

                // Navigate back to the dashboard of our app (except for last run
                if (i != numOfCustomers)
                {
                    _driver.Navigate().Back();
                }

            }

        }

        [Fact]
        public void Customers_Delete_Buttons_Navigate_To_Correct_Customers_Delete_Page()
        {
            // Navigate to the Customers page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/Customers");

            int numOfCustomers = _driver.FindElements(By.ClassName("customer-customer-row")).Count;

            // For each customer in the customer customer
            for (int i = 0; i < numOfCustomers; i++)
            {

                // Clicks on the delete button for this row 
                IWebElement delete = _driver.FindElement(By.CssSelector("#customer-" + (i + 1).ToString() + " .delete"));
                new Actions(_driver)
                .MoveToElement(delete)
                .Perform();
                new Actions(_driver)
                .MoveToElement(delete)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct delete page
                Assert.Equal("Delete Customer - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Customers/Delete?id=" + (i + 1).ToString(), _driver.Url);

                // Navigate back to the dashboard of our app (except for last run
                if (i != numOfCustomers)
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