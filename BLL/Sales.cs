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
        PhotoDBEntities bd;
        public Sales()
        {
            bd = new PhotoDBEntities();
        }

    }
}
