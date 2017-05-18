using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Models;

namespace SportsStore.Domain.Repository
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        List<Product> GetAll();
    }
}
