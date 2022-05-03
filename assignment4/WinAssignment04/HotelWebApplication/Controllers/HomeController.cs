using DBAccess;
using HotelWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;
using System.Web;


namespace HotelWebApplication.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Login(DBAccess.Customer customer)
        {
            using (masterEntities dx = new masterEntities())
            {
                var customerDetails = dx.Customer.Where(x => x.FirstName == customer.FirstName && x.Pass == customer.Pass).FirstOrDefault();
                if (customerDetails == null)
                {
                    customer.LoginErrorMessage = "Wrong ID or password";
                    return View("Index", customer);
                }

                else
                {
                    dynamic mymodel = new ExpandoObject();
                    mymodel.Customer = customer;
                    mymodel.Rooms = dx.HotelRoom.ToList();
                    return View("Booking", mymodel);
                }
            }
            
        }
        [HttpPost]
        public IActionResult CreateUser(Customer customer)
        {
            using (masterEntities dx = new masterEntities())
            {
                if (dx.Customer.Any(x => x.FirstName == customer.FirstName && x.LastName == customer.LastName))
                {
                    ViewBag.Message = "Username already exists";
                    return View("Index", customer);
                }
                dx.Customer.Add(customer);
                dx.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.message = "The user " + customer.FirstName + " " + customer.LastName + " is saved successfully";
            return View("Index", new Customer());
        }


    }
}