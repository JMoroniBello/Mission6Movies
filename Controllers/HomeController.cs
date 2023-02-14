using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6Movies.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieRecordContext _recordContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieRecordContext movie)
        {
            _logger = logger;
            _recordContext = movie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovies(MovieResponse ar)
        {   
            //record submitted movie in the database
            _recordContext.Add(ar);
            _recordContext.SaveChanges();
            //return the same page for adding more movies
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
