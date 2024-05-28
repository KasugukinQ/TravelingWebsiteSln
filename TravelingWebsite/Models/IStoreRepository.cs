namespace TravelingWebsite.Models
{
    public interface IStoreRepository
    {
        IQueryable<Package> Packages { get; }

        void SavePackage(Package p);
        void CreatePackage(Package p);
        void DeletePackage(Package p);
    }
}
