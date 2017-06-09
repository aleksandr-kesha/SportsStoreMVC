using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Domain.Models
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            var line = _lineCollection.FirstOrDefault(p => p.Product.ProductId == product.ProductId);

            if (line == null)
                _lineCollection.Add(new CartLine {Product = product, Quantity = quantity});
            else
                line.Quantity += quantity;
        }

        public void RemoveLine(Product product) => _lineCollection.RemoveAll(p => p.Product.ProductId == product.ProductId);

        public decimal ComputeTotalValue() => _lineCollection.Sum(e => e.Product.Price * e.Quantity);

        public void Clear() => _lineCollection.Clear();

        public IEnumerable<CartLine> Lines => _lineCollection;
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal Total => Quantity * Product.Price;
    }
}
