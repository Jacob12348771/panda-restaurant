using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace AutomatedTests
{
    public class MenuItemsTests : IDisposable
    {
        private readonly IWebDriver _driver;
        public MenuItemsTests() => _driver = new ChromeDriver();

 
        public void Menu_Items_Page_Loads()
        {
            // Navigates to the Menu Items page of our app
            _driver.Navigate()
                .GoToUrl("https://localhost:2345/MenuItems");
            // Checks that the page is the Menu Items page
            Assert.Equal("Menu Items - PandaRestaurant", _driver.Title);
            // Assert.Contains("Dashboard", _driver.PageSource);

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
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

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







        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

    }
}