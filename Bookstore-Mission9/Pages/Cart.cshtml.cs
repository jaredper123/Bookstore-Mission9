using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Bookstore_Mission9.Models;
using Bookstore_Mission9.Models.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bookstore_Mission9.Pages
{
    public class CartModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }
        public CartModel (IBookstoreRepository temp)
        {
            repo = temp;
        }
        public ShoppingCart shopcart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnurl)
        {
            ReturnUrl = returnurl ?? "/";
            shopcart = HttpContext.Session.GetJson<ShoppingCart>("shopcart") ?? new ShoppingCart(); ;
        }

        public IActionResult OnPost(int BookId, string returnurl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == BookId);
            shopcart = HttpContext.Session.GetJson<ShoppingCart>("shopcart") ?? new ShoppingCart();
            shopcart.AddItem(b, 1);

            HttpContext.Session.SetJson("shopcart", shopcart);
            return RedirectToPage(new { ReturnUrl = returnurl });
        }
    }
}
