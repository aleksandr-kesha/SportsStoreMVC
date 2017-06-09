using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Models;
using SportsStore.Domain.Repository;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;

        public CartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
                GetCart().AddItem(product, 1);

            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
                GetCart().RemoveLine(product);

            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            var cart = (Cart) Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }

        public ActionResult Index(string returnUrl)
        {
            var viewModel = new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            };

            return View(viewModel);
        }
    }
}