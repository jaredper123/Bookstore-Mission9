using Bookstore_Mission9.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_Mission9.Controllers
{
    public class CartController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private ShoppingCart cart { get; set; }
        public CartController (IPurchaseRepository temp, ShoppingCart sc)
        {
            repo = temp;
            cart = sc;
        }
        
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty.  Please add items before checking out!");
            }
            if (ModelState.IsValid)
            {
                purchase.Lines = cart.Items.ToArray();
                repo.SavePurchase(purchase);
                cart.ClearCart();

                return RedirectToPage("/Complete");
            }
            else
            {
                return View();
            }
        }
    }
}
