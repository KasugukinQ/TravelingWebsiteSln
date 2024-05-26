using Microsoft.AspNetCore.Mvc;
using TravelingWebsite.Controllers;
using TravelingWebsite.Models;

namespace TravelingWebsite.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Booking booking;

        public OrderController(IOrderRepository repository, Booking booking)
        {
            this.repository = repository;
            this.booking = booking;
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (booking.Lines.Count() == 0)
            {
                ModelState.AddModelError("",
                    "Sorry, you didnt book anything yet.");
            }
            if (ModelState.IsValid)
            {
                order.Lines = booking.Lines.ToArray();
                repository.SaveOrder(order);
                booking.Clear();
                return RedirectToPage("/Completed", new { orderId = order.OrderId });
            }
            else
            {
                return View();
            }
        }
    }
}