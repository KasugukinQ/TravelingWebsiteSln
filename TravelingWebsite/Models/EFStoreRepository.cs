
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

        public void CreatePackage(Package package)
        {
            context.Add(package);
            context.SaveChanges();
        }

        public void DeletePackage(Package package)
        {
            context.Remove(package);
            context.SaveChanges();
        }

        public void SavePackage(Package package)
        {
            context.SaveChanges();
        }
    }
}
