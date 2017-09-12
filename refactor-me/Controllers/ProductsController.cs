using System;
using System.Web.Http;
using refactor_me.Models;
using System.Linq;
using refactor_me.DTOs;
using System.Web.Http.Cors;
using System.Collections.Generic;

namespace refactor_me.Controllers
{
    [RoutePrefix("products")]
    [EnableCors("*","*","*")]
    public class ProductsController :
         ProductBaseController
    {
        public ProductsController(IProductRepository ProdRepo) : base(ProdRepo)
        {

        }
        //ProductContext ctx;

        //public ProductsController()
        //{
        //    ctx = new ProductContext();
        //}

        // GET: Products
        [Route]
        [HttpGet]
      public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(new {
                    Items = ProductRepo.GetAllProducts().ToList().Select(s => Factory.Create(s))
                });
            }
            catch (Exception)
            {
                return InternalServerError(new Exception("Server Error"));
            }

        }

        [Route]
        [HttpGet]
        public IHttpActionResult SearchByName(string name)
        {
            try
            {
                return Ok(ProductRepo.SearchByName(name).ToList().Select(s => Factory.Create(s)));
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
            try
            {
                Product P = ProductRepo.GetProduct(id);

                if (P == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(P));
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }

        [Route]
        [HttpPost]
        public IHttpActionResult Create(ProductDTO product)
        {
            try
            {
                bool outcome = ProductRepo.AddProduct(product);
                if (outcome == true)
                    return Ok("Success");
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError(new Exception("Server Error"));
            }
        }
        [Route("{id}")]
        [HttpPut]
        public IHttpActionResult Update(Guid id, ProductDTO product)
        {
            try
            {
                bool outcome = ProductRepo.UpdateProduct(id, product);
                if (outcome == true)
                    return Ok("Success");
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError(new Exception("Server Error"));
            }

        }

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                bool outcome = ProductRepo.Delete(id);
                if (outcome == true)
                    return Ok("Success");
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return InternalServerError(new Exception("Server Error"));
            }
        }

        [Route("{productId}/options")]
        [HttpGet]
        public IHttpActionResult GetOptions(Guid productId)
        {
            return Ok(new {
             items=   ProductRepo.GetOptions(productId).ToList().Select(s => Factory.Create(s))
            });
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public IHttpActionResult GetOption(Guid productId, Guid id)
        {
            try
            {
                ProductOption Opt = ProductRepo.GetOption(productId, id);
                if (Opt == null)
                    return NotFound();
                else
                    return Ok(Factory.Create(Opt));

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("{productId}/options")]
        [HttpPost]
        public IHttpActionResult CreateOption(Guid productId, ProductOptionDTO option)
        {

            try
            {
                bool outcome = ProductRepo.AddOption(productId, option);
                if (outcome == true)
                    return Ok("Success");
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError(new Exception("Server Error"));
            }

        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public IHttpActionResult UpdateOption(Guid id, ProductOptionDTO option)
        {
            try
            {
                bool outcome = ProductRepo.UpdateOption(id, option);
                if (outcome == true)
                    return Ok("Success");
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError(new Exception("Server Error"));
            }
        }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteOption(Guid id)
        {
            try
            {
                bool outcome = ProductRepo.DeleteOption(id);
                if (outcome == true)
                    return Ok("Success");
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError(new Exception("Server Error"));
            }

        }
    }
}