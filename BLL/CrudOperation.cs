using DAL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
