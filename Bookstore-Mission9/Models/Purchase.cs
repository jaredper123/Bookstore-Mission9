using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_Mission9.Models
{
    public class Purchase
    {
        [Key]
        [BindNever]
        public int PurchaseId { get; set; }
        [BindNever]
        public ICollection<ShoppingCartItem> Lines { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address.")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        [Required(ErrorMessage = "Please Enter Your City.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter Your State.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please Enter Your Country.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please Enter Your Zipcode.")]
        public string Zip { get; set; }

    }
}
