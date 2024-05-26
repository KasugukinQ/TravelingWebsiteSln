using Microsoft.AspNetCore.Mvc;
using TravelingWebsite.Models;

namespace TravelingWebsite.Components
{
    public class BookingSummaryViewComponent : ViewComponent
    {
        private Booking Booking;

        public BookingSummaryViewComponent(Booking Booking)
        {
            this.Booking = Booking;
        }

        public IViewComponentResult Invoke()
        {
            return View(Booking);
        }
    }
}
