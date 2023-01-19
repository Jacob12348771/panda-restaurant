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
                new Models.MenuItem{MenuItemName="Saturday Soup", MenuItemPrepTime=10, MenuItemPrice=14.50},
                new Models.MenuItem{MenuItemName="Beef Noodle Soup", MenuItemPrepTime=15, MenuItemPrice=11.60},
                new Models.MenuItem{MenuItemName="Super Secret Noodle Soup", MenuItemPrepTime=15, MenuItemPrice=9.50},
                new Models.MenuItem{MenuItemName="Panda's Veggie Special Soup", MenuItemPrepTime=20, MenuItemPrice=20.00},
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

            var customers = new Models.Customer[]
            {
                new Models.Customer{CustomerName="John"},
                new Models.Customer{CustomerName="Zara"},
                new Models.Customer{CustomerName="Lily"},
                new Models.Customer{CustomerName="Sidney"},
                new Models.Customer{CustomerName="Steve"},
                new Models.Customer{CustomerName="Simba"},
                new Models.Customer{CustomerName="Tim"}
            };

            context.Customer.AddRange(customers);
            context.SaveChanges();

            var orders = new Models.Order[]
            {
                new Models.Order{OrderStatus = Order.OrderStatusEnum.Created, OrderDatetime = new DateTime(2022, 5, 1, 8, 30, 00), TableID = 1, CustomerID = 1, MenuItem = new List<Models.MenuItem>{menuItems[1], menuItems[3], menuItems[4] } },
                new Models.Order{OrderStatus = Order.OrderStatusEnum.Ready, OrderDatetime = new DateTime(2022, 5, 12, 9, 40, 00), TableID = 2, CustomerID = 2, MenuItem = new List<Models.MenuItem>{menuItems[2], menuItems[0], menuItems[3] } },
                new Models.Order{OrderStatus = Order.OrderStatusEnum.Paid, OrderDatetime = new DateTime(2022, 5, 11, 13, 23, 00), TableID = 3, CustomerID = 3, MenuItem = new List<Models.MenuItem>{menuItems[5], menuItems[6], menuItems[1] } },
                new Models.Order{OrderStatus = Order.OrderStatusEnum.Created, OrderDatetime = new DateTime(2022, 5, 13, 15, 21, 00), TableID = 4, CustomerID = 4, MenuItem = new List<Models.MenuItem>{menuItems[2], menuItems[3], menuItems[6] } },
                new Models.Order{OrderStatus = Order.OrderStatusEnum.Created, OrderDatetime = new DateTime(2022, 5, 17, 15, 40, 00), TableID = 5, CustomerID = 5, MenuItem = new List<Models.MenuItem>{menuItems[5], menuItems[3], menuItems[2] } },
                new Models.Order{OrderStatus = Order.OrderStatusEnum.Preparing, OrderDatetime = new DateTime(2022, 5, 20, 8, 11, 00), TableID = 6, CustomerID = 6, MenuItem = new List<Models.MenuItem>{menuItems[5], menuItems[3], menuItems[4] } },
                new Models.Order{OrderStatus = Order.OrderStatusEnum.Ready, OrderDatetime = new DateTime(2022, 5, 24, 10, 07, 00), TableID = 7, CustomerID = 7, MenuItem = new List<Models.MenuItem>{menuItems[2], menuItems[6], menuItems[4] } }
            };

            context.Order.AddRange(orders);
            context.SaveChanges();
        }
    }
}
