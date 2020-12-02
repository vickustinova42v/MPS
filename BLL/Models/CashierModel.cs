﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    class CashierModel
    {
        public CashierModel() { }

        public CashierModel(Cashier cashiers)
        {
            Id = cashiers.Id;
            FIO = cashiers.FIO;
        }
        public int Id { get; set; }
        public string FIO { get; set; }
    }
}
