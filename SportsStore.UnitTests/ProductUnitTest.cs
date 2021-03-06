﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Linq;
using SportsStore.WebUI.Controllers;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.HtmlHelpers;
namespace SportsStore.UnitTests
{
    [TestClass]
    public class ProductUnitTest
    {
        [TestMethod]
        public void Can_Paginate()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>{
                new Product{ProductID=1,Name="P1"},
                new Product{ProductID=2,Name="P2"},
                new Product{ProductID=3,Name="P3"},
                new Product{ProductID=4,Name="P4"},
                new Product{ProductID=5,Name="P5"}
            }.AsQueryable());
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(null,2).Model;
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper myHelper=null;
            PagingInfo pagingInfo = new PagingInfo {CurrentPage=2,TotalItems=28,ItemsPerPage=10 };
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            MvcHtmlString result = myHelper.PageLinks(pagingInfo,pageUrlDelegate);
            Assert.AreEqual(result.ToString(),@"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a><a href=""Page3"">3</a>");
        }
    }
}
