using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TravelingWebsite.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public ICollection<BookingLine> Lines { get; set; } 
            = new List<BookingLine>();

        [Required(ErrorMessage = "Please enter a name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public string? Line1 { get; set; }

        [Required(ErrorMessage = "Please select your ending date!")]
        public string? Line2 { get; set; }

        [Required(ErrorMessage = "Please select your starting date!")]
        public string? Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city.")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Please enter a state/region.")]
        public string? State { get; set; }
        public string? Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country.")]
        public string? Country { get; set; }
        public bool GiftWrap { get; set; }

        [BindNever]
        public bool Shipped { get; set; }
    }
}
