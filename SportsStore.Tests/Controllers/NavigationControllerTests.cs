using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Models;
using SportsStore.Domain.Repository;
using SportsStore.WebUI.Controllers;

namespace SportsStore.Tests.Controllers
{
    [TestClass]
    public class NavigationControllerTests
    {
        [TestMethod]
        public void CanCreateCategories()
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(GetProducts);

            var target = new NavigationController(mock.Object);

            var results = ((IEnumerable<string>) target.Menu(null).Model).ToArray();

            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "Cat1");
            Assert.AreEqual(results[1], "Cat2");
            Assert.AreEqual(results[2], "Cat3");

        }

        [TestMethod]
        public void IndicatesSelectedCategory()
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(GetProducts);

            var target = new NavigationController(mock.Object);

            const string selectedCategory = "Cat2";

            string result = target.Menu(selectedCategory).ViewBag.SelectedCategory;

            Assert.AreEqual(selectedCategory, result);
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
