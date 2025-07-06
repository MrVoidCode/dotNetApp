using AutoMapper;
using SimpleApi.Entities;
using SimpleApi.models;

namespace SimpleApi.Profiles
{
    public class PointOfInterestProfiles : Profile
    {
        public PointOfInterestProfiles()
        {
            CreateMap<PointOfInterest, PointOfInterestDto>();
            CreateMap<PointOfInterest, PointOfInterestUpdateDto>();
            CreateMap<PointOfInterestUpdateDto, PointOfInterest>();
            CreateMap<PointOfInterestForCreationDto, PointOfInterest>();
        }
    }
}
