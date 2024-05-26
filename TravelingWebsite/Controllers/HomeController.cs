using Microsoft.AspNetCore.Mvc;
using TravelingWebsite.Models;
using TravelingWebsite.Models.ViewModels;

namespace TravelingWebsite.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;
        public HomeController(IStoreRepository repository)
        {
            this.repository = repository;
        }
    
        public ViewResult Index(string? category, int packagePage = 1)
            => View(new PackagesListViewModel
            {
                Packages = repository.Packages
                    .Where(p => category == null ||
                    p.Category == category)
                    .OrderBy(p => p.PackageID)
                    .Skip((packagePage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = packagePage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null
                        ? repository.Packages.Count()
                        : repository.Packages.Where(e =>
                            e.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}
