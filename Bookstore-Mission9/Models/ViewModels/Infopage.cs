using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.ViewModels
{
    public class Infopage
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }
        //Decide how many pages
        public int TotalPage => (int) Math.Ceiling(((double) TotalNumBooks / BooksPerPage));
        //Info Database

    }
}
