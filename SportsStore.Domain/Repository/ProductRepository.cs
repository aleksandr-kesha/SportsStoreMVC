using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Models;

namespace SportsStore.Domain.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext = new DataContext();
        
        public IQueryable<Product> Products => _dataContext.Products;

        public List<Product> GetAll()
        {
            return _dataContext.Products.ToList();
        }
    }
}
