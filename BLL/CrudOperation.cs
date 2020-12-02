using DAL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class CrudOperation
    {
        PhotoDBEntities bd;
        public CrudOperation()
        {
            bd = new PhotoDBEntities();
        }

        public List<ProductModel> CheksList()
        {
            return bd.Product.ToList().Select(i => new ProductModel(i)).ToList();
        }
    }
}
