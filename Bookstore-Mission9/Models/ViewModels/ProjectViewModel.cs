using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.ViewModels
{
    public class ProjectViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public Infopage Infopage { get; set; }
    }
}
