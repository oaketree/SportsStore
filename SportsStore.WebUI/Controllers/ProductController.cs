﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        private IProductRepository repository;
        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }
        public ActionResult List()
        {
            return View(repository.Products);
        }

    }
}
