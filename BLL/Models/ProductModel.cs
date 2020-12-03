using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public double Cost { get; set; }
        public int Category_FK { get; set; }
        public string Category_All_Prod { get; set; }

        public ProductModel() { }

        public ProductModel(Product products, List<CategoryModel> categorys)
        {

            Id = products.Id;
            Name = products.Name;
            Number = products.Number;
            Cost = products.Cost;
            Category_FK = products.Category_FK;
            Category_All_Prod = categorys.Where(i => i.Id == Category_FK).FirstOrDefault().Name;
            
        }
    }
}
