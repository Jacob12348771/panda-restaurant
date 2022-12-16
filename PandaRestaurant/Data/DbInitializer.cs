using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PandaRestaurant.Models;

namespace PandaRestaurant.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Prevent db being overwritten when testing.
            if (context.Table.Any() || context.Order.Any() || context.MenuItem.Any() || context.Employee.Any() || context.Customer.Any())
            {
                return;
            }
            

            var tables = new Models.Table[]
            {
                new Models.Table{TableOccupied=true},
                new Models.Table{TableOccupied=false},
                new Models.Table{TableOccupied=true},
                new Models.Table{TableOccupied=true},
                new Models.Table{TableOccupied=false},
                new Models.Table{TableOccupied=true},
                new Models.Table{TableOccupied=false}
            };

            context.Table.AddRange(tables);
            context.SaveChanges();

            var menuItems = new Models.MenuItem[]
            {
                new Models.MenuItem{MenuItemName="Beetroot Soup", MenuItemPrepTime=15, MenuItemPrice=12.70},
                new Models.MenuItem{MenuItemName="Cabbage Soup", MenuItemPrepTime=13, MenuItemPrice=15.10},
                new Models.MenuItem{MenuItemName="Mushroom Soup", MenuItemPrepTime=16, MenuItemPrice=13.50},
                new Models.MenuItem{MenuItemName="Chicken Noodle Soup", MenuItemPrepTime=15, MenuItemPrice=11.60},
                new Models.MenuItem{MenuItemName="Tomato Soup", MenuItemPrepTime=15, MenuItemPrice=9.50},
                new Models.MenuItem{MenuItemName="Panda's Special Soup", MenuItemPrepTime=20, MenuItemPrice=20.00},
                new Models.MenuItem{MenuItemName="Saturday Soup", MenuItemPrepTime=10, MenuItemPrice=14.50}
            };

            context.MenuItem.AddRange(menuItems);
            context.SaveChanges();

            var employees = new Models.Employee[]
            {
                new Models.Employee{EmployeeName="Jeff", EmployeePosition = Employee.EmployeePositionEnum.Waiter, Tables = new List<Models.Table>{tables[0], tables[3] } },
                new Models.Employee{EmployeeName="James", EmployeePosition = Employee.EmployeePositionEnum.Chef},
                new Models.Employee{EmployeeName="Chris", EmployeePosition = Employee.EmployeePositionEnum.Manager, Tables = new List<Models.Table>{tables[4]} },
                new Models.Employee{EmployeeName="Anna", EmployeePosition = Employee.EmployeePositionEnum.Waiter, Tables = new List<Models.Table>{tables[2], tables[3] } },
                new Models.Employee{EmployeeName="Oliver", EmployeePosition = Employee.EmployeePositionEnum.Waiter, Tables = new List<Models.Table>{tables[1]} },
                new Models.Employee{EmployeeName="Lea", EmployeePosition = Employee.EmployeePositionEnum.Chef},
                new Models.Employee{EmployeeName="Nick", EmployeePosition = Employee.EmployeePositionEnum.Waiter, Tables = new List<Models.Table>{tables[5], tables[6] } },

            };

            context.Employee.AddRange(employees);
            context.SaveChanges();
        }
    }
}
