using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class RecieptLineModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int Product_FK { get; set; }
        public int Reciept_FK { get; set; }
        public string ProductName { get; set; }
        public RecieptLineModel(RecieptLine recieptlines, List<ProductModel> products)
        {
            Id = recieptlines.Id;
            Count = recieptlines.Count;
            Product_FK = recieptlines.Product_FK;
            Reciept_FK = recieptlines.Reciept_FK;
            ProductName = products.Where(i => i.Id == Product_FK).FirstOrDefault().Name;
        }
    }
}
