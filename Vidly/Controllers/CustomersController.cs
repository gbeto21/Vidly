using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Models.Customer> mlisCustomers =
            new List<Models.Customer>()
            {
                new Models.Customer(){ Id = 1, Name = "Valle"},
                new Models.Customer(){ Id = 2, Name = "Rojo"}
            };

        // GET: Customers
        public ActionResult Index()
        {
            return View(GetCustomerViewModel());
        }

        [Route("customers/details/{pCustomerId}")]
        public ActionResult Details(int pCustomerId)
        {
            var customer = GetCustomer(pCustomerId);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private CustomersViewModel GetCustomerViewModel()
        {
            return new CustomersViewModel()
            {
                Customers = mlisCustomers
            };
        }

        private Models.Customer GetCustomer(int pCustomerId)
        {
            return mlisCustomers.Find(cus => cus.Id == pCustomerId);
        }
    }
}
