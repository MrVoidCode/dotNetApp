using Microsoft.EntityFrameworkCore;
using SimpleApi.DbContexts;
using SimpleApi.Entities;

namespace SimpleApi.Repositories
{
    public class PointOfInterestInfoRepository : IPointOfInterestInfoRepository
    {
        private readonly CityInfoDbContext _dbContext;
        private readonly ICityInfoRepository _cityInfoRepository;
        
        public PointOfInterestInfoRepository(CityInfoDbContext context, ICityInfoRepository cityInfoRepository)
        {
            _dbContext = context;
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));

        }
        public async Task<IEnumerable<PointOfInterest>> GetPointOfInterestsAsync(int cityId)
        {
            return await _dbContext.PointOfInterests.Where(c => c.CityId == cityId).ToListAsync();
        }

        public async Task<PointOfInterest?> GetPointOfInterestsAsync(int cityId, int pointOfInterestId)
        {
            return await _dbContext.PointOfInterests.Where(c => c.Id == pointOfInterestId && c.CityId == cityId).FirstOrDefaultAsync();
        }



        public async Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest)
        {
            var city = await _cityInfoRepository.GetCitiesAsync(cityId, false);
            if (city!=null)
            {
                city.PointOfInterests.Add(pointOfInterest);

            }
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync() > 0);
        }

        public void RemovePointOfInterest(PointOfInterest pointOfInterest)
        {
            _dbContext.PointOfInterests.Remove(pointOfInterest);
        }
    }
}
