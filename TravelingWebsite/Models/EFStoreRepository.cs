
namespace TravelingWebsite.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDBContext context;

        public EFStoreRepository(StoreDBContext context)
        {
            this.context = context;
        }
        public IQueryable<Package> Packages => context.Packages;
    }
}
