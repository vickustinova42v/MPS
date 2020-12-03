using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
   public class RecieptModel
    {
        public int Id { get; set; }
        public System.DateTime DateTime { get; set; }
        public double Result { get; set; }
        public int Cashier_FK { get; set; }
        public string Cashier_All_Prod { get; set; }
        public RecieptModel(Reciept reciepts, List<CashierModel> cashiers)
        {
            Id = reciepts.Id;
            DateTime = reciepts.DateTime;
            Result = reciepts.Result;
            Cashier_FK = reciepts.Cashier_FK;
            Cashier_All_Prod = cashiers.Where(i => i.Id == Cashier_FK).FirstOrDefault().FIO;
        }
    }
}
