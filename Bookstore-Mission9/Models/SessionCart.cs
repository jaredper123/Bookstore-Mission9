using Bookstore.Models;
using Bookstore_Mission9.Models.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Bookstore_Mission9.Models
{
    public class SessionCart : ShoppingCart
    {
        public static ShoppingCart GetShoppingCart (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();

            cart.Session = session;

            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Book b, int qty)
        {
            base.AddItem(b, qty);
            Session.SetJson("Cart", this);
        }

        public override void RemoveItem(Book b)
        {
            base.RemoveItem(b);
            Session.SetJson("Cart", this);
        }
        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("Cart");
        }
    }
}
