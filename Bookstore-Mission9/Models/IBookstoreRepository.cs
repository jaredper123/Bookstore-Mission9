using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    //setting a repository up via the database we have before.
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
