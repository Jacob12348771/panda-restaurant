using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace AutomatedTests
{
    public class MenuItemsTests : IDisposable
    {
        private readonly IWebDriver _driver;
        public MenuItemsTests() => _driver = new ChromeDriver();

        [Fact]
        public void Menu_Items_Page_Loads()
        {
            // Navigates to the Menu Items page of our app
            _driver.Navigate()
                .GoToUrl("https://localhost:2345/MenuItems");
            // Checks that the page is the Menu Items page
            Assert.Equal("Menu Items - PandaRestaurant", _driver.Title);

        }

        [Fact]
        public void Menu_Items_Table_Rows_Navigate_To_Correct_Menu_Items_Details_Page()
        {
            // Navigate to the Menu Items page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345");

            int numOfOrders = _driver.FindElements(By.ClassName("menu-item-table-row")).Count;

            // For each menu item in the menu item table
            for (int i = 0; i < numOfOrders; i++)
            {

                // Clicks on the row in the table 
                IWebElement tableRow = _driver.FindElement(By.Id("menu-item-" + (i + 1).ToString()));
                new Actions(_driver)
                .MoveToElement(tableRow)
                .Perform();
                new Actions(_driver)
                .MoveToElement(tableRow)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct details page
                Assert.Equal("Menu Item Details - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/MenuItems/Details?id=" + (i + 1).ToString(), _driver.Url);

                // Navigate back to the dashboard of our app (except for last run
                if (i != numOfOrders)
                {
                    _driver.Navigate().Back();
                }

            }

        }


        [Fact]
        public void Menu_Items_Create_Button_Navigates_To_The_Create_Page()
        {
            // Navigate to the Menu Items page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/MenuItems");

                // Clicks on the create menu item button
                IWebElement create = _driver.FindElement(By.Id("create"));
                new Actions(_driver)
                .MoveToElement(create)
                .Perform();
                new Actions(_driver)
                .MoveToElement(create)
                .Click()
                .Perform();

                // Checks that we have navigated to the create menu item page
                Assert.Equal("Create Menu Item - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/MenuItems/Create", _driver.Url);


        }


        [Fact]
        public void Menu_Items_Edit_Buttons_Navigate_To_Correct_Menu_Items_Edit_Page()
        {
            // Navigate to the Menu Items page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/MenuItems");

            int numOfOrders = _driver.FindElements(By.ClassName("menu-item-table-row")).Count;

            // For each menu item in the menu item table
            for (int i = 0; i < numOfOrders; i++)
            {

                // Clicks on the edit button for this row 
                IWebElement edit = _driver.FindElement(By.CssSelector("#menu-item-" + (i + 1).ToString() + " .edit"));
                new Actions(_driver)
                .MoveToElement(edit)
                .Perform();
                new Actions(_driver)
                .MoveToElement(edit)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct edit page
                Assert.Equal("Edit Menu Item - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/MenuItems/Edit?id=" + (i + 1).ToString(), _driver.Url);

                // Navigate back to the dashboard of our app (except for last run
                if (i != numOfOrders)
                {
                    _driver.Navigate().Back();
                }

            }

        }

        [Fact]
        public void Menu_Items_Delete_Buttons_Navigate_To_Correct_Menu_Items_Delete_Page()
        {
            // Navigate to the Menu Items page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/MenuItems");

            int numOfOrders = _driver.FindElements(By.ClassName("menu-item-table-row")).Count;

            // For each menu item in the menu item table
            for (int i = 0; i < numOfOrders; i++)
            {

                // Clicks on the delete button for this row 
                IWebElement delete = _driver.FindElement(By.CssSelector("#menu-item-" + (i + 1).ToString() + " .delete"));
                new Actions(_driver)
                .MoveToElement(delete)
                .Perform();
                new Actions(_driver)
                .MoveToElement(delete)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct delete page
                Assert.Equal("Delete Menu Item - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/MenuItems/Delete?id=" + (i + 1).ToString(), _driver.Url);

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