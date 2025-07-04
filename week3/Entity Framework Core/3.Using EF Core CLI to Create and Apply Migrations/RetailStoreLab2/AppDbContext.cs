using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using RetailStoreLab2.Models;

namespace RetailStoreLab2
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
     @"Server=.\SQLEXPRESS;Database=RetailInventoryLab2DB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;"
 );

        }
    }
}

