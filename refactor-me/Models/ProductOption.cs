using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace refactor_me.Models
{
    [Table("ProductOption")]
    public class ProductOption
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Product product { get; set; }

        public ProductOption()
        {
            //product = new Product();
        }
    }
}