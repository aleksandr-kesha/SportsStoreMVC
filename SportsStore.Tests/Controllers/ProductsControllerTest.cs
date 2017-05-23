using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Models;
using SportsStore.Domain.Repository;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void List()
        {
            var mock = new Mock<IProductRepository>();

            // Arrange
            var controller = new ProductsController(mock.Object);

            // Act
            var result = controller.List() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanPaginate()
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(r => r.Products).Returns(GetProducts);

            var controller = new ProductsController(mock.Object)
            {
                PageSize = 3
            };

            var products = ((ProductListViewModel)controller.List(2).Model).Products;

            Assert.IsTrue(products.Count == 2);
            Assert.AreEqual(products[0].Name, "P4");
            Assert.AreEqual(products[1].Name, "P5");
        }


        [TestMethod]
        public void CanSendPaginateViewModel()
        {
            var mock = new Mock<IProductRepository>();

            var products = GetProducts();

            mock.Setup(r => r.Products).Returns(products);

            const int currentPage = 2;
            const int itemsPerPage = 3;

            var controller = new ProductsController(mock.Object)
            {
                PageSize = itemsPerPage
            };

            var result = (ProductListViewModel)controller.List(currentPage).Model;

            var pagingInfo = result.PagingInfo;

            Assert.AreEqual(pagingInfo.CurrentPage, currentPage);
            Assert.AreEqual(pagingInfo.ItemsPerPage, itemsPerPage);
            Assert.AreEqual(pagingInfo.TotalItems, products.Count());
            Assert.AreEqual(pagingInfo.TotalPages, 2);
        }

        private IQueryable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"},
                new Product {ProductId = 4, Name = "P4"},
                new Product {ProductId = 5, Name = "P5"}
            }.AsQueryable();
        } 
    }
}