using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieRecordContext daContext { get; set; }

        //Constructor
        public HomeController(MovieRecordContext movie)
        {
            daContext = movie;
        }

        public IActionResult Index ()
        {
            return View();
        }


        public IActionResult Podcasts ()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovies ()
        {
            ViewBag.Categories = daContext.Categories.ToList();

            return View(new MovieResponse());
        }

        [HttpPost]
        public IActionResult AddMovies (MovieResponse ar)
        {   
            if (ModelState.IsValid)
            {
                //record submitted movie in the database
                daContext.Add(ar);
                daContext.SaveChanges();
                //return the same page for adding more movies
                return View("subValidation");
            }
            else
            {
                ViewBag.Categories = daContext.Categories.ToList();
                return View(ar);
            }
            
        }
        
        public IActionResult subValidation ()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Library ()
        {
            var movies = daContext.Responses
                .Include(x => x.Category)
                .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var movie = daContext.Responses.Single(x => x.MovieID == id);
            return View("AddMovies", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieResponse update)
        {
            daContext.Update(update);
            daContext.SaveChanges();
            return RedirectToAction("Library");
        }



        [HttpGet]
        public IActionResult Delete (int id)
        {
            var movie = daContext.Responses.Single(x => x.MovieID == id);
           
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse mr)
        {
            daContext.Responses.Remove(mr);
            daContext.SaveChanges();
            return RedirectToAction("Library");
        }

    }
}
