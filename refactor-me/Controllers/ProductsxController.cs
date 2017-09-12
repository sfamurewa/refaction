using System;
using System.Net;
using System.Web.Http;
using refactor_me.Models;
using System.Linq;
using System.Data.Entity;

namespace refactor_me.Controllers
{
    [RoutePrefix("productsx")]
    public class ProductsxController : ApiController
    {
        ProductContext ctx;
        public ProductsxController()
        {
            ctx = new ProductContext();
        }
        [Route]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(ctx.Products);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
          
        }

        [Route]
        [HttpGet]
        public IHttpActionResult SearchByName(string name)
        {
            try
            {
                return Ok(ctx.Products.Where(n=>n.Name.Contains(name)));
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
            //return new Products(name);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetProduct(Guid id)
        {
            //var product = new Product(id);ffffffffffffffffffffffffffffffff
            //if (product.IsNew)
            //    throw new HttpResponseException(HttpStatusCode.NotFound);

            //return product;

            try
            {
                return Ok(ctx.Products.Where(n => n.Id==id).FirstOrDefault());
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }

        [Route]
        [HttpPost]
        public IHttpActionResult Create(Product product)
        {
            if (!(product==null))
            {
                Product NewProd = new Product
                {
                    Id = Guid.NewGuid(),
                    Price = product.Price,
                    Description = product.Description,
                    Name = product.Name,
                    DeliveryPrice = product.DeliveryPrice
                };

                ctx.Products.Add(NewProd);
                ctx.SaveChanges();
                return Ok("Success");
            }
            {
                return BadRequest();
            }
           
        }

        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(Guid id, Product product)
        {
            var orig = ctx.Products.Where(n => n.Id == id).FirstOrDefault();

            if (!(orig == null))
            {
                orig.Price = product.Price;
                orig.Description = product.Description;
                orig.Name = product.Name;
                   orig.DeliveryPrice = product.DeliveryPrice;
                 ctx.SaveChanges();
                return Ok("Success");
            }
            {
                return NotFound();
            }

        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            var orig = ctx.Products.Where(n => n.Id == id).FirstOrDefault();

            if (!(orig == null))
            {
                ctx.Products.Remove(orig);
               ctx.SaveChanges();
                return Ok("Success");
            }
            {
                return NotFound();
            }
        }

        [Route("{productId}/options")]
        [HttpGet]
        public IHttpActionResult GetOptions(Guid productId)
        {
            try
            {
                var orig = ctx.Products.Include(t=>t.Options) .Where(n => n.Id == productId).FirstOrDefault();
                return Ok(orig.Options);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
           
            //return new ProductOptions(productId);
        }


        [Route("{productId}/options/{id}")]
        [HttpGet]
        public IHttpActionResult GetOption(Guid productId, Guid id)
        {
            try
            {
                var orig = ctx.Products.Include(t => t.Options).Where(n => n.Id == productId).FirstOrDefault();
                return Ok(orig.Options.Where(n => n.Id == id).FirstOrDefault());
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }

        [Route("{productId}/options")]
        [HttpPost]
        public IHttpActionResult CreateOption(Guid productId, ProductOption option)
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

                ctx.Options.Add(NewOpt);
                ctx.SaveChanges();
                return Ok("Success");
                           }
            {
                return BadRequest();
            }
     
        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateOption(Guid id, ProductOption option)
        {
            var orig = ctx.Options.Where(n => n.Id == id).FirstOrDefault();

            if (!(orig == null))
            {
                orig.Name = option.Name;
                orig.Description = option.Description;
                ctx.SaveChanges();
                return Ok("Success");
            }
            {
                return NotFound();
            }
        }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteOption(Guid id)
        {
            var orig = ctx.Options.Where(n => n.Id == id).FirstOrDefault();

            if (!(orig == null))
            {
                ctx.Options.Remove(orig);
                ctx.SaveChanges();
                return Ok("Success");
            }
            {
                return NotFound();
            }
        }

    }
}
