using System.Collections.Generic;
using System.Linq;
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
            var result = controller.List(null);

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

            var products = ((ProductListViewModel)controller.List(null,2).Model).Products;

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

            var result = (ProductListViewModel)controller.List(null, currentPage).Model;

            var pagingInfo = result.PagingInfo;

            Assert.AreEqual(pagingInfo.CurrentPage, currentPage);
            Assert.AreEqual(pagingInfo.ItemsPerPage, itemsPerPage);
            Assert.AreEqual(pagingInfo.TotalItems, products.Count());
            Assert.AreEqual(pagingInfo.TotalPages, 2);
        }

        [TestMethod]
        public void CanFilterProducts()
        {
            var mock = new Mock<IProductRepository>();

            var products = GetProducts();

            mock.Setup(r => r.Products).Returns(products);

            const int itemsPerPage = 3;
            const string category = "Cat2";

            var controller = new ProductsController(mock.Object)
            {
                PageSize = itemsPerPage
            };

            var result = ((ProductListViewModel) controller.List(category).Model).Products.ToArray();

            Assert.AreEqual(result.Length, 2);

            Assert.IsTrue(result.All(p => p.Category == category));

            Assert.IsTrue(result[0].Name == "P3");
            Assert.IsTrue(result[1].Name == "P4");
        }

        private static IQueryable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product {ProductId = 1, Name = "P1", Category = "Cat1"},
                new Product {ProductId = 2, Name = "P2", Category = "Cat1"},
                new Product {ProductId = 3, Name = "P3", Category = "Cat2"},
                new Product {ProductId = 4, Name = "P4", Category = "Cat2"},
                new Product {ProductId = 5, Name = "P5", Category = "Cat3"}
            }.AsQueryable();
        } 
    }
}