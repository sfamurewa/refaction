using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using refactor_me.Models;
using refactor_me.DTOs;

namespace refactor_me.Controllers
{
    public class ProductBaseController :ApiController
      {
        private IProductRepository Prepo;

        private DTOFactory _DTOFactory;
        public ProductBaseController(IProductRepository _Prepo)
        {
            Prepo = _Prepo;
        }
        // GET: Base
        protected IProductRepository ProductRepo {
            get
            {
                return Prepo;
            }
        }

        protected DTOFactory Factory
        {
            get
            {
                if (_DTOFactory == null)
                {
                    _DTOFactory = new DTOFactory();
                }
                return _DTOFactory;
            }
        }
    }
}