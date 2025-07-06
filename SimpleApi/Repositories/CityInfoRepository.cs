using Microsoft.EntityFrameworkCore;
using SimpleApi.DbContexts;
using SimpleApi.Entities;

namespace SimpleApi.Repositories
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private CityInfoDbContext _dbContext;
        public CityInfoRepository(CityInfoDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(CityInfoDbContext));
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _dbContext.Cities
                .OrderBy(c => c.Name).ToListAsync();
            
        }

        public async Task<City?> GetCitiesAsync(int cityId, bool includePointOfInterest)
        {
            if (includePointOfInterest)
            {
                return await _dbContext.Cities.Include(c => c.PointOfInterests)
                    .Where(c => c.Id == cityId).FirstOrDefaultAsync();
            }

            return await _dbContext.Cities.Where(c =>c.Id ==cityId).FirstOrDefaultAsync();
        }

        public async Task<bool> GetCityAsync(int cityId)
        {
            return await _dbContext.Cities.AnyAsync(c => c.Id == cityId);
        }
    }
}
