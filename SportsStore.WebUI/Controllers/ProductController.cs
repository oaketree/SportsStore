using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using Ninject;
using SportsStore.Domain.Concrete;
using SportsStore.WebUI.Models;
namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public int PageSize = 4;
        private IProductRepository repository;
        public ProductController(IProductRepository productRepository)
        {
            //IKernel ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();
            //repository = ninjectKernel.Get<IProductRepository>();
            repository = productRepository;

        }
        public ViewResult List(int page = 1)
        {
            ProductsListViewModel viewModel = new Models.ProductsListViewModel
            {
                Products = repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                pagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = repository.Products.Count() }
            };
            return View(viewModel);
        }
    }
}
