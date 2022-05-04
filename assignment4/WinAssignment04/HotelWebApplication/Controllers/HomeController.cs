using DBAccess;
using HotelWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Dynamic;
using System.Web;


namespace HotelWebApplication.Controllers
{
    public class HomeController : Controller
    {
        
        CustomerModel model;

        
        public IActionResult Index()
        {
            return View();
        }
        

        public IActionResult Login(Customer customer)
        {
            using (masterEntities dx = new masterEntities())
            {
                var customerDetails = dx.Customer.Where(x => x.FirstName == customer.FirstName && x.Pass == customer.Pass).FirstOrDefault();
                if (customerDetails == null)
                {
                    ViewBag.message = "Wrong ID or password";
                    return View("Index", customer);
                }

                else
                {
                    model = new CustomerModel();

                    foreach (Customer cust in dx.Customer.ToList())
                    {
                        if (customerDetails.FirstName == cust.FirstName && customerDetails.Pass == cust.Pass)
                        {
                            model.customer = cust;
                        }   
                    }

                    
                    model.firstName = customer.FirstName;
                    model.lastName = customer.LastName;
                    
                    model.ID = model.customer.ID;

                    foreach (ReservationTable res in dx.ReservationTable.ToList())
                    {
                        if (res.ResNumb == model.customer.ResID)
                        {
                            model.reservation = res;
                        }
                    }
                    
                    if (model.reservation == null)
                    {
                        model.reservation = new ReservationTable();
                        ModelState.Clear();
                        ViewBag.Message = "";
                        return View("Booking", model);
                    }
                    ModelState.Clear();
                    return View("CheckStatus", model);
                   
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
            return View("Index", customer);
        }
        
        [HttpPost]
        public ActionResult CreateReservation(CustomerModel model)
        {
            if (model.startTime == null || model.endTime == null || model.reservation.RoomSize <= 0 || model.reservation.BedNumb <= 0)
            {
                ViewBag.Message = "Error, prøv igjen";
                return View("Booking", model);
            } else
            {
                using (masterEntities dx = new masterEntities())
                {
                    int resNumber = 0;

                    foreach (ReservationTable reservation in dx.ReservationTable.ToList())
                    {
                        if (reservation.ResNumb > resNumber)
                        {
                            resNumber = (int)reservation.ResNumb;
                        }
                    }
                    resNumber++;

                    String dateStart = model.startTime.ToString().Substring(0, 6) + model.startTime.ToString().Substring(8, 2);

                    String dateEnd = model.endTime.ToString().Substring(0, 6) + model.endTime.ToString().Substring(8, 2);

                    ReservationTable res = model.reservation;
                    res.ResNumb = resNumber;
                    res.FirstName = model.firstName;
                    res.LastName = model.lastName;
                    res.RoomSize = model.reservation.RoomSize;
                    res.BedNumb = model.reservation.BedNumb;
                    res.DateStart = dateStart;
                    res.DateEnd = dateEnd;
                    res.RoomNumb = null;
                    model.reservation = res;

                    foreach (Customer cust in dx.Customer.ToList())
                    {
                        if (cust.ID == model.ID)
                        {
                            cust.ResID = resNumber;
                        }
                    }

                    dx.ReservationTable.Add(res);

                    dx.SaveChanges();

                    ViewBag.Message = "Reservation added, your reservation number is: " + res.ResNumb;

                    return View("CheckStatus", model);
                }
            }
        }

        
        public IActionResult CheckStatus(CustomerModel model)
        {
            ViewBag.message = "Room is booked, your id is ";
            return View("CheckStatus", model);

        }

    }
}