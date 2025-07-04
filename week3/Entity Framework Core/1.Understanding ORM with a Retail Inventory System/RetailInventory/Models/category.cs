using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailInventory.Models
{
    public class Category
    {
        public int CategoryId { get; set; }          // Primary Key
        public string Name { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
