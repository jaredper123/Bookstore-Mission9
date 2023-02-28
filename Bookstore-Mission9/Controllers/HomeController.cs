using Bookstore.Models;
using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore_Mission9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBookstoreRepository repo;


        public HomeController(ILogger<HomeController> logger, IBookstoreRepository temp)
        {
            _logger = logger;
            repo = temp;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int numBooks = 10;

            var page = new ProjectViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip(((pageNum - 1) * numBooks))
                .Take(numBooks),

                Infopage = new Infopage
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = numBooks,
                    CurrentPage = pageNum
                }
            };

            return View(page);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
