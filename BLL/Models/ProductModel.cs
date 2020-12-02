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
        public ProductModel() { }

        public ProductModel(Product products)
        {
            Id = products.Id;
            Name = products.Name;
            Number = products.Number;
            Cost = products.Cost;
            Category_FK = products.Category_FK;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public double Cost { get; set; }
        public int Category_FK { get; set; }
    }
}
