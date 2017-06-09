using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Repository;

namespace SportsStore.WebUI.Controllers
{
    public class NavigationController : Controller
    {
        private readonly IProductRepository _productRepository;

        public NavigationController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            var categories = _productRepository.Products.Select(p => p.Category).Distinct().OrderBy(c => c).ToList();

            return PartialView(categories);
        }
    }
}