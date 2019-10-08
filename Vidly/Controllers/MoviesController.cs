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

            return View(movie);
            //return Content("Hola Mundo");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (pageIndex.HasValue == false)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex = {0} & sortBy = {1}",
                pageIndex,
                sortBy));
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}