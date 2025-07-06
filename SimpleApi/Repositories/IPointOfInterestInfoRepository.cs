using Microsoft.Identity.Client;
using SimpleApi.Entities;

namespace SimpleApi.Repositories
{
    public interface IPointOfInterestInfoRepository
    {
        Task<IEnumerable<PointOfInterest>> GetPointOfInterestsAsync(int cityId);
        Task<PointOfInterest?> GetPointOfInterestsAsync(int cityId, int pointOfInterestId);
        Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest);
        Task<bool> SaveChangesAsync();
        void RemovePointOfInterest(PointOfInterest pointOfInterest);
    }
}
