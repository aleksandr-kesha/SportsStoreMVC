using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Models;

namespace SportsStore.Tests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void CanAddNewLines()
        {
            var p1 = new Product {ProductId = 1, Name = "P1"};
            var p2 = new Product {ProductId = 2, Name = "P2"};

            var targer = new Cart();

            targer.AddItem(p1, 1);
            targer.AddItem(p2, 1);

            var results = targer.Lines.ToArray();

            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Product, p1);
            Assert.AreEqual(results[1].Product, p2);
        }

        [TestMethod]
        public void CanAddQuantityForExistingLines()
        {
            var p1 = new Product { ProductId = 1, Name = "P1" };
            var p2 = new Product { ProductId = 2, Name = "P2" };

            var targer = new Cart();

            targer.AddItem(p1, 1);
            targer.AddItem(p2, 1);
            targer.AddItem(p1, 10);

            var results = targer.Lines.OrderBy(p => p.Product.ProductId).ToArray();

            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Quantity, 11);
            Assert.AreEqual(results[1].Quantity, 1);
        }

        [TestMethod]
        public void CanRemoveLine()
        {
            var p1 = new Product { ProductId = 1, Name = "P1" };
            var p2 = new Product { ProductId = 2, Name = "P2" };
            var p3 = new Product { ProductId = 3, Name = "P3" };

            var targer = new Cart();

            targer.AddItem(p1, 1);
            targer.AddItem(p2, 3);
            targer.AddItem(p3, 5);
            targer.AddItem(p2, 1);

            targer.RemoveLine(p2);

            Assert.AreEqual(targer.Lines.Count(p => p.Product == p2), 0);
            Assert.AreEqual(targer.Lines.Count(), 2);
        }

        [TestMethod]
        public void CalculateCartTotal()
        {
            var p1 = new Product { ProductId = 1, Name = "P1", Price = 100M};
            var p2 = new Product { ProductId = 2, Name = "P2", Price = 50M};

            var targer = new Cart();

            targer.AddItem(p1, 1);
            targer.AddItem(p2, 1);
            targer.AddItem(p1, 3);

            var results = targer.ComputeTotalValue();

            Assert.AreEqual(results, 450);
        }

        [TestMethod]
        public void CanClearCart()
        {
            var p1 = new Product { ProductId = 1, Name = "P1" };
            var p2 = new Product { ProductId = 2, Name = "P2" };

            var targer = new Cart();

            targer.AddItem(p1, 1);
            targer.AddItem(p2, 1);
           
            targer.Clear();

            Assert.AreEqual(targer.Lines.Count(), 0);
        }
    }
}
