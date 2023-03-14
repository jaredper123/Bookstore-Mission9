using Microsoft.AspNetCore.Mvc;
using Bookstore_Mission9.Models;
using Bookstore.Models;

namespace Bookstore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private ShoppingCart cart;
        public CartSummaryViewComponent(ShoppingCart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
