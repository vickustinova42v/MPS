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
        public void DeleteProducts(string id)
        {
            const string SQL = "DELETE FROM Product WHERE Id = ";
            string sql1 = SQL + id;
            bd.Database.ExecuteSqlCommand(sql1);
        }

        public void DeleteCashiers(string id)
        {
            const string SQL = "DELETE FROM Cashier WHERE Id = ";
            string sql1 = SQL + id;
            bd.Database.ExecuteSqlCommand(sql1);
        }
        public class result
        {
            public int Id { get; set; }
            public string FIO { get; set; }
            public System.DateTime DateTime { get; set; }
            public double Result { get; set; }
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
            public double Result { get; set; }
        }

        public object SearchRecieptCashier(int c)
        {
            SqlParameter param1 = new SqlParameter("@id", c);
            var resultCash = bd.Database.SqlQuery<resultCash>("SearchRecieptDate @id", new object[] {param1}).ToList();
            return resultCash;
        }
    }
}
