using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace AutomatedTests
{
    public class EmployeesTests : IDisposable
    {
        private readonly IWebDriver _driver;
        public EmployeesTests() => _driver = new ChromeDriver();

        [Fact]
        public void Employees_Page_Loads()
        {
            // Navigates to the Employees page of our app
            _driver.Navigate()
                .GoToUrl("https://localhost:2345/Employees");
            // Checks that the page is the Employees page
            Assert.Equal("Employees - PandaRestaurant", _driver.Title);

        }

        [Fact]
        public void Employees_Employee_Rows_Navigate_To_Correct_Employees_Details_Page()
        {
            // Navigate to the Employees page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345");

            int numOfEmployees = _driver.FindElements(By.ClassName("employee-employee-row")).Count;

            // For each employee in the employee employee
            for (int i = 0; i < numOfEmployees; i++)
            {

                // Clicks on the row in the employee 
                IWebElement employeeRow = _driver.FindElement(By.Id("employee-" + (i + 1).ToString()));
                new Actions(_driver)
                .MoveToElement(employeeRow)
                .Perform();
                new Actions(_driver)
                .MoveToElement(employeeRow)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct details page
                Assert.Equal("Employee Details - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Employees/Details?id=" + (i + 1).ToString(), _driver.Url);

                // Navigate back to the dashboard of our app (except for last run
                if (i != numOfEmployees)
                {
                    _driver.Navigate().Back();
                }

            }

        }


        [Fact]
        public void Employee_Create_Button_Navigates_To_The_Create_Page()
        {
            // Navigate to the Employees page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/Employees");

                // Clicks on the create employee button
                IWebElement create = _driver.FindElement(By.Id("create"));
                new Actions(_driver)
                .MoveToElement(create)
                .Perform();
                new Actions(_driver)
                .MoveToElement(create)
                .Click()
                .Perform();

                // Checks that we have navigated to the create employee page
                Assert.Equal("Create Employee - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Employees/Create", _driver.Url);


        }


        [Fact]
        public void Employees_Edit_Buttons_Navigate_To_Correct_Employees_Edit_Page()
        {
            // Navigate to the Employees page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/Employees");

            int numOfEmployees = _driver.FindElements(By.ClassName("employee-employee-row")).Count;

            // For each employee in the employee employee
            for (int i = 0; i < numOfEmployees; i++)
            {

                // Clicks on the edit button for this row 
                IWebElement edit = _driver.FindElement(By.CssSelector("#employee-" + (i + 1).ToString() + " .edit"));
                new Actions(_driver)
                .MoveToElement(edit)
                .Perform();
                new Actions(_driver)
                .MoveToElement(edit)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct edit page
                Assert.Equal("Edit Employee - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Employees/Edit?id=" + (i + 1).ToString(), _driver.Url);

                // Navigate back to the dashboard of our app (except for last run
                if (i != numOfEmployees)
                {
                    _driver.Navigate().Back();
                }

            }

        }

        [Fact]
        public void Employees_Delete_Buttons_Navigate_To_Correct_Employees_Delete_Page()
        {
            // Navigate to the Employees page of our app
            _driver.Navigate()
         .GoToUrl("https://localhost:2345/Employees");

            int numOfEmployees = _driver.FindElements(By.ClassName("employee-employee-row")).Count;

            // For each employee in the employee employee
            for (int i = 0; i < numOfEmployees; i++)
            {

                // Clicks on the delete button for this row 
                IWebElement delete = _driver.FindElement(By.CssSelector("#employee-" + (i + 1).ToString() + " .delete"));
                new Actions(_driver)
                .MoveToElement(delete)
                .Perform();
                new Actions(_driver)
                .MoveToElement(delete)
                .Click()
                .Perform();

                // Checks that we have navigated to the correct delete page
                Assert.Equal("Delete Employee - PandaRestaurant", _driver.Title);
                Assert.Equal("https://localhost:2345/Employees/Delete?id=" + (i + 1).ToString(), _driver.Url);

                // Navigate back to the dashboard of our app (except for last run
                if (i != numOfEmployees)
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