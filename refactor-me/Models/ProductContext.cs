using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace refactor_me.Models
{
    public class ProductContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOption> Options { get; set; }
        public ProductContext(): base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
                                        |DataDirectory|Database.mdf;Integrated Security=True")
        {
         
        }
    }
}