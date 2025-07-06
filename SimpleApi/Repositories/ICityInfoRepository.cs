using SimpleApi.Entities;

namespace SimpleApi.Repositories
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City?> GetCitiesAsync(int cityId, bool includePointOfInterest);
        Task<bool> GetCityAsync(int cityId);


    }
}
