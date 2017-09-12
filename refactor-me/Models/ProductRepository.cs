using System;
using System.Linq;
using refactor_me.DTOs;


namespace refactor_me.Models
{
    public class ProductRepository:IProductRepository
            {
        private ProductContext _ctx;
        public ProductRepository(ProductContext ctx)
        {
            _ctx = new ProductContext();
        }

        #region " Product Routines"
        public IQueryable<Product> GetAllProducts()
        {
            try
            {
                if (_ctx==null)
                {
                    throw new Exception("context has not been initialized");
                }
                return _ctx.Products.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetProduct(Guid id)
        {
           return _ctx.Products.Where(n => n.Id == id).FirstOrDefault();
        }

       public IQueryable<Product> SearchByName(string name)
        {
            return _ctx.Products.Where(n => n.Name.Contains(name)).AsQueryable();
        }

        public bool AddProduct(ProductDTO product)
        {
            try
            {
                 if (!(product == null))
                            {
                                Product NewProd = new Product
                                {
                                    Id = Guid.NewGuid(),
                                    Price = product.Price,
                                    Description = product.Description,
                                    Name = product.Name,
                                    DeliveryPrice = product.DeliveryPrice
                                };

                                _ctx.Products.Add(NewProd);
                                _ctx.SaveChanges();
                    return true;
                            }
                            {
                                return false;
                            }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
          public bool UpdateProduct(Guid id, ProductDTO product)
        {
          try
            {
                      var orig = _ctx.Products.Where(n => n.Id == id).FirstOrDefault();

                                if (!(orig == null))
                                {
                                    orig.Price = product.Price;
                                    orig.Description = product.Description;
                                    orig.Name = product.Name;
                                    orig.DeliveryPrice = product.DeliveryPrice;
                                    _ctx.SaveChanges();
                                    return  true;
                                }
                                {
                                    return  false;
                                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     public bool Delete(Guid id)
        {
            try
            {
                var orig = _ctx.Products.Where(n => n.Id == id).FirstOrDefault();

                if (!(orig == null))
                {
                    _ctx.Products.Remove(orig);
                    _ctx.SaveChanges();
                    return true;
                }
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region "Product Option Routines"
        public ProductOption GetOption(Guid productId, Guid id)
        {
            try
            {
                return _ctx.Options.Where(s => s.ProductId == productId && s.Id==id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IQueryable<ProductOption> GetOptions(Guid productId)
        {
            try
            {
                return _ctx.Options.Where(s => s.ProductId == productId).AsQueryable();
             }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public bool AddOption(Guid productId, ProductOptionDTO option)
        {
            try
            {
                
                if (!(option == null) && (!string.IsNullOrEmpty(productId.ToString())))
                {
                    ProductOption NewOpt = new ProductOption
                    {
                        Id = Guid.NewGuid(),
                        Name = option.Name,
                        Description = option.Description,
                        ProductId = productId
                    };

                    _ctx.Options.Add(NewOpt);
                    _ctx.SaveChanges();
                    return true;
                }
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public bool UpdateOption(Guid id, ProductOptionDTO option)
        {
            try
            {
                var orig = _ctx.Options.Where(n => n.Id == id).FirstOrDefault();

                if (!(orig == null))
                {
                    orig.Name = option.Name;
                    orig.Description = option.Description;
                    _ctx.SaveChanges();
                    return true;
                }
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteOption(Guid id)
        {
            try
            {
                var orig = _ctx.Options.Where(n => n.Id == id).FirstOrDefault();

                if (!(orig == null))
                {
                    _ctx.Options.Remove(orig);
                    _ctx.SaveChanges();
                    return true;
                }
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
