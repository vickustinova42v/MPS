﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class RecieptLineModel
    {
        public RecieptLineModel() { }

        public RecieptLineModel(RecieptLine recieptlines)
        {
            Id = recieptlines.Id;
            Count = recieptlines.Count;
            Product_FK = recieptlines.Product_FK;
            Reciept_FK = recieptlines.Reciept_FK;
        }
        public int Id { get; set; }
        public int Count { get; set; }
        public int Product_FK { get; set; }
        public int Reciept_FK { get; set; }
    }
}