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
   
    public class Sales
    {
        CrudOperation crud = new CrudOperation();
        PhotoDBEntities bd;
        public Sales()
        {
            bd = new PhotoDBEntities();
        }

        public void Update(string product_id, string name, string number, int cost, int category_id, int sale, string function_id)
        {
            double result;
            int costAfter = 1;
            if(sale == 1)
            {
                if(cost <= 500)
                {
                    sale = 10;
                    result = cost * 0.9;
                    costAfter = (int)Math.Round(result);
                }
                else if (cost > 500 && cost <= 1000)
                {
                    sale = 30;
                    result = cost * 0.7;
                    costAfter = (int)Math.Round(result);
                }
                else if (cost > 1000)
                {
                    sale = 50;
                    result = cost * 0.5;
                    costAfter = (int)Math.Round(result);
                }
            }

            else if (sale == 2)
            {
                if (cost <= 500)
                {
                    sale = 5;
                    result = cost * 0.95;
                    costAfter = (int)Math.Round(result);
                }
                else if (cost > 500 && cost <= 1000)
                {
                    sale = 10;
                    result = cost * 0.9;
                    costAfter = (int)Math.Round(result);
                }
                else if (cost > 1000)
                {
                    sale = 20;
                    result = cost * 0.8;
                    costAfter = (int)Math.Round(result);
                }
            }

            else if (sale == 0)
            {
                sale = 0;
                result = cost;
                costAfter = (int)Math.Round(result);
            }

            if (function_id == "1")
            {
                crud.UpdateProduct(product_id, name, number, cost, category_id, sale, costAfter);
            }
            else if (function_id == "2")
            {
                crud.CreateProduct(name, number, cost, category_id, sale, costAfter);
            }
        }
    }
}
