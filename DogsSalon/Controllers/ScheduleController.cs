using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DogsSalon.Models;
using DogsSalon.ViewModels;
using DogsSalon.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace DogsSalon.Controllers

    
{
   // [Authorize]
    public class ScheduleController : Controller
    {
        private readonly UserManager<User> _userManager;

        private ApplicationDbContext _context;
        public ScheduleController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;

        }



        public async Task<IActionResult> Index(string searchString, string dateString)
        {
            //ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["NameFilter"] = searchString;
            ViewData["DateFilter"] = dateString;

            var orders = from o in _context.orders.Include(o => o.customer) select o;
            // var orders = _context.orders.Include(o => o.customer);
            //var query = _context.orders.AsNoTracking().OrderBy(o => o.timeOfOrder);
           // var model = await PagingList.CreateAsync(query, 5, 1);

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.customer.name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(dateString))
            {
                orders = orders.Where(o => Equals(o.timeOfOrder , DateTime.Parse(dateString)));
            }

            orders = orders.OrderBy(o => o.timeOfOrder);

           
            return View(await orders.AsNoTracking().ToListAsync());

          //  return View(orders);
        }


        public ActionResult Details(int id)
        {
            var order = _context.orders.SingleOrDefault(c => c.id == id);
            //if (order == null)
            //{
            //    return new  HttpStatusCodeResult(404)();
            //}

            return View(order);
        }

        public IActionResult New()
        {
            var id = _userManager.GetUserId(User);
            
            Order order = new Order();
            order.customerId = Int32.Parse(id);
            order.createDate = DateTime.Today;

            Console.WriteLine(order.createDate.ToString());
            Console.WriteLine("sdfsdfsdxfdsxfcvsdfds");
            return View(order);
        }
        [HttpPost]
        public IActionResult Save(Order newOrder)
        {

            if(!ModelState.IsValid)
            {
                var Order = newOrder;

                return View("New");
            }

            if(newOrder.id == 0)
            {
                newOrder.createDate = DateTime.Today;
                _context.orders.Add(newOrder);
            }
            else
            {
                var orderInDb = _context.orders.Single(o => o.id == newOrder.id);
                orderInDb.timeOfOrder = newOrder.timeOfOrder;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Schedule");
        }

        //[HttpGet]
        //public PartialViewResult Edit(int id)
        //{
        //    var orderDb = _context.orders.Where(o => o.id == id).FirstOrDefault();

        //    Order order = new Order();
        //    order.id = orderDb.id;
        //    order.createDate = orderDb.createDate;
        //    order

        //}

        public IActionResult Edit(int id)
        {
            var order = _context.orders.SingleOrDefault(o => o.id == id);

            return View("New",order);
        }


        [HttpPost]
        public async Task<IActionResult> deleteOrder( Order order)
        {
            
            var orderInDb = _context.orders.Single(o => o.id == order.id);

            Console.WriteLine(order);
          //  if (orderInDb == null)
           //     throw new ApplicationException("order not found");

            _context.orders.Remove(orderInDb);

            await _context.SaveChangesAsync();



            return RedirectToAction("Index");

        }


    }
}