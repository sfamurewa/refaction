using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace refactor_me.Models
{
    [Table("Product")]
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }

        [JsonIgnore]
        public ICollection<ProductOption> Options { get; set; }

        public Product()
        {
            //Options = new List<ProductOption>();
        }

    }
}