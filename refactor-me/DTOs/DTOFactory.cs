using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using refactor_me.Models;

namespace refactor_me.DTOs
{
    public class DTOFactory
    {
        public DTOFactory()
        {

        }

        public ProductDTO Create(Product product)
        {
            return new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                DeliveryPrice = product.DeliveryPrice,
                Description = product.Description
            };
        }

        public ProductOptionDTO Create(ProductOption option)
        {
            return new ProductOptionDTO()
            {
                Id = option.Id,
                Name = option.Name,
                ProductId = option.ProductId,
                Description=option.Description
 };
        }
    }
}

