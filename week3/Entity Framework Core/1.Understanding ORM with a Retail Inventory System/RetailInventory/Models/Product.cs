using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailInventory.Models
{
    public class Product
    {
        public int ProductId { get; set; }           // Primary Key
        public string Name { get; set; } = string.Empty;
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }          // Foreign Key
        public Category? Category { get; set; }      // Navigation Property
    }
}

