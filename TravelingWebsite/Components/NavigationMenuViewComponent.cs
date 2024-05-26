using Microsoft.AspNetCore.Mvc;
using TravelingWebsite.Models;

namespace TravelingWebsite.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repository)
        {
            this.repository = repository;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Packages
                    .Select(x => x.Category)
                    .Distinct()
                    .OrderBy(x => x));
        }
    }
}
