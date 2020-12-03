using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryModel(Category categorys)
        {
            Id = categorys.Id;
            Name = categorys.Name;
        }
    }
}
