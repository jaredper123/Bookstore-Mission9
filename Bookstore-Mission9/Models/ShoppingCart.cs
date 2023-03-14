using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_Mission9.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
    
        public virtual void AddItem (Book b, int qty)
        {
            ShoppingCartItem line = Items
                .Where(p => p.Book.BookId == b.BookId)
                .FirstOrDefault();
            if (line == null)
            {
                Items.Add(new ShoppingCartItem
                {
                    Book = b,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem (Book b)
        {
            Items.RemoveAll(x => x.Book.BookId == b.BookId);
        }

        public virtual void ClearCart()
        {
            Items.Clear();
        }
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => (double)x.Quantity * x.Book.Price);
            return sum;
        }
    }

    

    public class ShoppingCartItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
