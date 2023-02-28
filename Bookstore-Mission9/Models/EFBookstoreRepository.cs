using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext context { get; set; }
        
        //setting the context via the repository interface in a nother file.

        public EFBookstoreRepository(BookstoreContext tmp)
        {
            context = tmp;
        }

        public IQueryable<Book> Books => context.Books;

    }
}
