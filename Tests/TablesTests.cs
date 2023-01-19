using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace AutomatedTests
{
    public class TablesTests : IDisposable
    {
        private readonly IWebDriver _driver;
        public TablesTests() => _driver = new ChromeDriver();

        [Fact]
        public void Tables_Page_Loads()
        {
            // Navigates to the Tables page of our app
            _driver.Navigate()
                .GoToUrl("https://localhost:2345/Tables");
            // Checks that the page is the Tables page
            Assert.Equal("Tables - PandaRestaurant", _driver.Title);

        }

        [Fact]
        public void Tables_Table_Rows_Navigate_To_Correct_Tables_Details_Page()
        {
            // Navigate to the Tables page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345");

            int numOfTables = _driver.FindElements(By.ClassName("table-table-row")).Count;

            // For each table in the table table
            for (int i = 0; i < numOfTables; i++)
            {

                // Clicks on the row in the table 
                IWebElement tableRow = _driver.FindElement(By.Id("table-" + (i + 1).ToString()));
                new Actions(_driver)
                .MoveToElement(tableRow)
                .Perform();
                new Actions(_driver)
                .MoveToElement(tableRow)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct details page
                Assert.Equal("Table Details - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Tables/Details?id=" + (i + 1).ToString(), _driver.Url);

                // Navigate back to the dashboard of our app (except for last run
                if (i != numOfTables)
                {
                    _driver.Navigate().Back();
                }

            }

        }


        [Fact]
        public void Table_Create_Button_Navigates_To_The_Create_Page()
        {
            // Navigate to the Tables page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/Tables");

                // Clicks on the create table button
                IWebElement create = _driver.FindElement(By.Id("create"));
                new Actions(_driver)
                .MoveToElement(create)
                .Perform();
                new Actions(_driver)
                .MoveToElement(create)
                .Click()
                .Perform();

                // Checks that we have navigated to the create table page
                Assert.Equal("Create Table - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Tables/Create", _driver.Url);


        }


        [Fact]
        public void Tables_Edit_Buttons_Navigate_To_Correct_Tables_Edit_Page()
        {
            // Navigate to the Tables page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/Tables");

            int numOfTables = _driver.FindElements(By.ClassName("table-table-row")).Count;

            // For each table in the table table
            for (int i = 0; i < numOfTables; i++)
            {

                // Clicks on the edit button for this row 
                IWebElement edit = _driver.FindElement(By.CssSelector("#table-" + (i + 1).ToString() + " .edit"));
                new Actions(_driver)
                .MoveToElement(edit)
                .Perform();
                new Actions(_driver)
                .MoveToElement(edit)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct edit page
                Assert.Equal("Edit Table - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Tables/Edit?id=" + (i + 1).ToString(), _driver.Url);

                // Navigate back to the dashboard of our app (except for last run
                if (i != numOfTables)
                {
                    _driver.Navigate().Back();
                }

            }

        }

        [Fact]
        public void Tables_Delete_Buttons_Navigate_To_Correct_Tables_Delete_Page()
        {
            // Navigate to the Tables page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/Tables");

            int numOfTables = _driver.FindElements(By.ClassName("table-table-row")).Count;

            // For each table in the table table
            for (int i = 0; i < numOfTables; i++)
            {

                // Clicks on the delete button for this row 
                IWebElement delete = _driver.FindElement(By.CssSelector("#table-" + (i + 1).ToString() + " .delete"));
                new Actions(_driver)
                .MoveToElement(delete)
                .Perform();
                new Actions(_driver)
                .MoveToElement(delete)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct delete page
                Assert.Equal("Delete Table - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Tables/Delete?id=" + (i + 1).ToString(), _driver.Url);

                // Navigate back to the dashboard of our app (except for last run
                if (i != numOfTables)
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