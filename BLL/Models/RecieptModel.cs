using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    class RecieptModel
    {
        public RecieptModel() { }

        public RecieptModel(Reciept reciepts)
        {
            Id = reciepts.Id;
            DateTime = reciepts.DateTime;
            Result = reciepts.Result;
            Cashier_FK = reciepts.Cashier_FK;
        }
        public int Id { get; set; }
        public System.DateTime DateTime { get; set; }
        public double Result { get; set; }
        public int Cashier_FK { get; set; }
    }
}
