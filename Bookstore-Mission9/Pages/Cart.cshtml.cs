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
        public ShoppingCart shopcart { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel (IBookstoreRepository temp, ShoppingCart s)
        {
            repo = temp;
            shopcart = s;
        }
        public void OnGet(string returnurl)
        {
            ReturnUrl = returnurl ?? "/";
        }

        public IActionResult OnPost(int BookId, string returnurl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == BookId);
            shopcart.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnurl });
        }

        public IActionResult OnPostRemove (int bookid, string returnUrl)
        {
            shopcart.RemoveItem(shopcart.Items.First(x => x.Book.BookId == bookid).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
