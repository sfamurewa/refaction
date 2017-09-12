using System;
using System.Linq;
using refactor_me.DTOs;


namespace refactor_me.Models
{
   public interface IProductRepository
    {
         IQueryable<Product> GetAllProducts();
        IQueryable<Product> SearchByName(string name);
        Product GetProduct(Guid id);
        bool AddProduct(ProductDTO product);
        bool UpdateProduct(Guid id, ProductDTO product);
        bool Delete(Guid id);
        IQueryable<ProductOption> GetOptions(Guid productId);
        ProductOption GetOption(Guid productId, Guid id);
        bool AddOption(Guid productId, ProductOptionDTO option);
        bool UpdateOption(Guid id, ProductOptionDTO option);
        bool DeleteOption(Guid id);
       
    }
}
