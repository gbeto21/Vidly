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

        /*
         Ejemplo cuando no se especifica el mapeo del router.
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }

        */

        /// <summary>Routed map.</summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        /// <remarks>For more information, google: "ASP.NET MVC Attribute Route Constraints."</remarks>
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}