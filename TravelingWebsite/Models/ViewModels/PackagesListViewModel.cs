namespace TravelingWebsite.Models.ViewModels
{
    public class PackagesListViewModel
    {
        public PackagesListViewModel() { }
        public IEnumerable<Package> Packages { get; set; } 
            = Enumerable.Empty<Package>();

        public PagingInfo PagingInfo { get; set; } = new();
        public string? CurrentCategory {  get; set; }
    }
}
