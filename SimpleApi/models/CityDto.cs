using Microsoft.Extensions.Primitives;

namespace SimpleApi.models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public int CountPointOfInterest 
        {
            get
            {
                
                return PointOfInterests.Count;
            }
        }

        public ICollection<PointOfInterestDto> PointOfInterests { get; set; } = new List<PointOfInterestDto>();

    }
}
