using DAL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BLL
{
    public class CrudOperation
    {
        PhotoDBEntities bd;
        public CrudOperation()
        {
            bd = new PhotoDBEntities();
        }
        public List<ProductModel> ProductList()
        {
         return bd.Product.ToList().Select(i => new ProductModel(i, CategoryList())).ToList();   
        }
        public List<RecieptModel> RecieptList()
        {
            return bd.Reciept.ToList().Select(i => new RecieptModel(i, CashierList())).ToList();
        }
        public List<CashierModel> CashierList()
        {
            return bd.Cashier.ToList().Select(i => new CashierModel(i)).ToList();
        }
        public List<CategoryModel> CategoryList()
        {
            return bd.Category.ToList().Select(i => new CategoryModel(i)).ToList();
        }
        public List<RecieptLineModel> RecieptLineList()
        {
            return bd.RecieptLine.ToList().Select(i => new RecieptLineModel(i, ProductList())).ToList();
        }
        public void DeleteProducts(string id)
        {
            const string SQL = "DELETE FROM Product WHERE Id = ";
            string sql1 = SQL + id;
            bd.Database.ExecuteSqlCommand(sql1);
            bd.SaveChanges();
        }
        public class result
        {
            public int Id { get; set; }
            public string FIO { get; set; }
            public System.DateTime DateTime { get; set; }
            public int Result { get; set; }
        }

        public object SearchRecieptDate(DateTime a, DateTime b)
        {
            SqlParameter param1 = new SqlParameter("@date1", a);
            SqlParameter param2 = new SqlParameter("@date2", b);
            var result = bd.Database.SqlQuery<result>("SearchRecieptCashier @date1,@date2", new object[] { param1, param2 }).ToList();
            return result;
        }

        public class resultCash
        {
            public int Id { get; set; }
            public string FIO { get; set; }
            public System.DateTime DateTime { get; set; }
            public int Result { get; set; }
        }

        public object SearchRecieptCashier(int c)
        {
            SqlParameter param1 = new SqlParameter("@id", c);
            var resultCash = bd.Database.SqlQuery<resultCash>("SearchRecieptDate @id", new object[] {param1}).ToList();
            return resultCash;
        }

        public void CreateProduct(string name_product, string number, int cost, int category_fk, int sale, int costSale)
        {

            string sql = "INSERT INTO Product (Name, Number, Cost, Category_FK, Sale, CostAfterSale) VALUES ('" + name_product + "','" + number + "'," + cost + ","+ category_fk + "," + sale + "," + costSale + ");";
            bd.Database.ExecuteSqlCommand(sql);
            bd.SaveChanges();

        }

        public void UpdateProduct(string id, string name_product, string number, int cost, int category_fk, int sale, int costSale)
        {
            string sql_update = "UPDATE Product SET Name = '" + name_product + "', Number = '" + number + "', Cost = " + cost + ", Category_FK =" + category_fk + " , Sale =" + sale + " , CostAfterSale =" + costSale + "   WHERE Id = " + id + " ;";
            bd.Database.ExecuteSqlCommand(sql_update);
            bd.SaveChanges();

        }

        public void CreateCashier(string FIO_Cashier, string Login, string Password)
        {

            string sql = "INSERT INTO Cashier (FIO, Login, Password) VALUES ('" + FIO_Cashier + "','" + Login + "','" + Password + "');";
            bd.Database.ExecuteSqlCommand(sql);
            bd.SaveChanges();

        }

        public void UpdateCashier(string id, string FIO_Cashier, string Login, string Password)
        {
            string sql_update = "UPDATE Cashier SET FIO = '" + FIO_Cashier + "', Login ='" + Login + "', Password = '" + Password + "'   WHERE Id = " + id + " ;";
            bd.Database.ExecuteSqlCommand(sql_update);
            bd.SaveChanges();
        }

    }
}
