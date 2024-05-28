using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TravelingWebsite.Models
{
    public class Package
    {
        public long? PackageID { get; set; }

        [Required(ErrorMessage = "Please enter a Booking Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; } = string.Empty;
    }
}
