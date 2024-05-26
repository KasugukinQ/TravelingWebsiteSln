using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravelingWebsite.Infrastructure;
using TravelingWebsite.Models;

namespace TravelingWebsite.Pages
{
    public class BookingModel : PageModel
    {
        private IStoreRepository repository;

        public BookingModel(IStoreRepository repository, Booking Booking)
        {
            this.repository = repository;
            this.Booking = Booking;
        }

        public Booking Booking { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Booking = HttpContext.Session.GetJson<Booking>("Booking")
            //   ?? new Booking();
        }

        public IActionResult OnPost(long packageId, string returnUrl)
        {
            Package? package = repository.Packages
                .FirstOrDefault(p => p.PackageID == packageId);

            if (package != null) 
            {
                //Booking = HttpContext.Session.GetJson<Booking>("Booking")
                //    ?? new Booking();
                Booking.AddItem(package, 1);
                //HttpContext.Session.SetJson("Booking", Booking);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long packageId,
            string returnUrl) 
        {
            Booking.RemoveLine(Booking.Lines.First(cl =>
                cl.Package.PackageID == packageId).Package);
            return RedirectToPage(new {returnUrl = returnUrl});
        }
    }
}
