using AutoMapper;
using SimpleApi.Entities;
using SimpleApi.models;

namespace SimpleApi.Profiles
{
    public class CityProfiles : Profile
    {
        public CityProfiles()
        {
            CreateMap<Entities.City, models.CityWithoutPointOfInterestDto>();
            CreateMap<Entities.City, models.CityDto>();
            
        }
    }
}
