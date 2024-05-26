namespace TravelingWebsite.Models
{
    public interface IStoreRepository
    {
        IQueryable<Package> Packages { get; }
    }
}
