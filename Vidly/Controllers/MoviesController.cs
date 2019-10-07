using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        // public ViewResult
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Glory road." };

            //return View(movie);
            //return Content("Hola Mundo");
            //return HttpNotFound();
            //return new EmptyResult();
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }
    }
}