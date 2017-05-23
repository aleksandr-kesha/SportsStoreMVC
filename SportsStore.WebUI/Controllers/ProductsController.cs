using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Repository;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public int PageSize = 4;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: Product
        public ViewResult List(int page = 1)
        {
            var products =
                _productRepository.Products.OrderBy(p => p.ProductId).Skip((page - 1)*PageSize).Take(PageSize).ToList();

            var productsViewModel = new ProductListViewModel
            {
                Products = products,
                PagingInfo = new PagingInfo
                {
                    TotalItems = _productRepository.Products.Count(),
                    ItemsPerPage = PageSize,
                    CurrentPage = page,
                }
            };

            if (productsViewModel.PagingInfo.CurrentPage > productsViewModel.PagingInfo.TotalPages)
                return View("Error");

            return View(productsViewModel);
        }
    }
}