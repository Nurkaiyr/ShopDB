using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopHW
{
    class ShopActions
    {
        public ShopActions()
        {
            ShopDB = CreateShopDataSet();
        }
        public DataSet ShopDB { get; set; }

        private DataSet CreateShopDataSet()
        {
            #region orders
            DataSet shopDB = new DataSet("ShopDB");
            DataTable orders = new DataTable("Orders");
            orders.Columns.Add("id", typeof(int));
            orders.Columns.Add("CustomerID", typeof(int));
            orders.Columns.Add("EmployeeID", typeof(int));
            orders.Columns.Add("ProductID", typeof(int));
            orders.Columns.Add("OrderDate", typeof(DateTime));
            orders.Columns["Id"].AutoIncrement = true;
            orders.PrimaryKey = new DataColumn[] { orders.Columns["id"] };
            #endregion
            #region customers
            DataTable customers = new DataTable("Customers");
            customers.Columns.Add("id", typeof(int));
            customers.Columns.Add("Fullname", typeof(string));
            customers.Columns.Add("Age", typeof(int));
            customers.Columns["id"].AutoIncrement = true;
            customers.PrimaryKey = new DataColumn[] { customers.Columns["id"] };
            #endregion
            #region Employee
            DataTable employee = new DataTable("Employee");
            employee.Columns.Add("id", typeof(int));
            employee.Columns.Add("Fullname", typeof(string));
            employee.Columns.Add("Age", typeof(int));
            employee.Columns["id"].AutoIncrement = true;
            employee.PrimaryKey = new DataColumn[] { employee.Columns["id"] };
            #endregion
            #region Products
            DataTable products = new DataTable("Products");
            products.Columns.Add("id", typeof(int));
            products.Columns.Add("name", typeof(string));
            products.Columns.Add("price", typeof(decimal));
            products.Columns["id"].AutoIncrement = true;
            products.PrimaryKey = new DataColumn[] { products.Columns["id"] };
            #endregion
            #region OrderDetails
            DataTable orderDetails = new DataTable("OrderDetails");
            orderDetails.Columns.Add("id", typeof(int));
            orderDetails.Columns.Add("orderID", typeof(int));
            orderDetails.Columns.Add("ordertime", typeof(DateTime));
            orderDetails.Columns["id"].AutoIncrement = true;
            orderDetails.PrimaryKey = new DataColumn[] { orderDetails.Columns["id"] };
            #endregion
            shopDB.Tables.AddRange(new DataTable[] { orders, customers, employee, products, orderDetails });
            
            #region Relations
            shopDB.Relations.Add("FK_CUSTOMERS_ID", customers.Columns["id"], orders.Columns["CustomerID"]);
            shopDB.Relations.Add("FK_EMPLOYEE_ID", employee.Columns["id"], orders.Columns["EmployeeID"]);
            shopDB.Relations.Add("FK_PRODUCT_ID", products.Columns["id"], orders.Columns["ProductID"]);
            #endregion

            return shopDB;

        }
    }
}
