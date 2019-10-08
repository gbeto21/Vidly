using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        // public ViewResult
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Glory road." };

            /*Returning data to the view 
             * 1. ViewData["Movie"] = movie;
                  return View();
                  En éste ejemplo, en la vista se tiene que 
                  hacer un cast al objeto del modelo, porque 
                  todos los objetos del ViewData, son del tipo
                  objeto. Además, la palabra: "Movie" está hardcodeada
                  en la llave del diccionario.

             * 2. ViewBag.Movie = movie;
                  return View();
                  En éste ejemplo se utiliza la propiedad variable,
                  ViewBag, pero si el nombre de la propiedad cambia,
                  también se tiene que cambiar en la vista y se tiene
                  que hacer el cast.

              * 3. return View(movie);
              *   Es la forma más sencilla de trabajar con los modelos.
                  Con éste método, lo que pasa internamente es 
                  lo siguiente:
                  var viewResult = new ViewResult();
                  viewResult.ViewData.Model = movie;

             */

            var customers = new List<Customer>
            {
                 new Customer { Name = "Customer 1"},
                 new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            /*Return diferents views
            return Content("Hola Mundo");
            return HttpNotFound();
            return new EmptyResult();
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
            */
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