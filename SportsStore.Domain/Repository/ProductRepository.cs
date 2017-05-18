using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Models;

namespace SportsStore.Domain.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IQueryable<Product> Products { get; } 

        public List<Product> GetAll()
        {
            return new List<Product>();
        }
    }
}
