using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogsSalon.Models;
using System.Net.Http;
using System.Web;
using Microsoft.EntityFrameworkCore;
using DogsSalon.Data;
using Microsoft.AspNetCore.Authorization;



namespace DogsSalon.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult New()
        {
            return View();
        }
        public ViewResult Index()
        {
            var customers = _context.Customers;  
            return View(customers);
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.id == id);
            if (customer == null)
            {
                return new HttpNotFoundResult();
            }

            return View(customer);
        }

        public class HttpNotFoundResult : ActionResult
        {
            private const int NotFoundCode = 404;

            public void ExecuteResult(ControllerContext context)
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }

                context.HttpContext.Response.StatusCode = NotFoundCode;
            }
        }

    }
}
