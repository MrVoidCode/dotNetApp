using SimpleApi.models;

namespace SimpleApi
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>
            {
                new CityDto() { Id = 1, Name = "Tehran", Description = "hello from Tehran", PointOfInterests  = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto(){Id = 1, Name = "ambshar1", Description = "so good1"},
                    new PointOfInterestDto(){Id = 2, Name = "ambshar1", Description = "so good1"},
                    new PointOfInterestDto(){Id = 3, Name = "ambshar1", Description = "so good1"}
                }},
                new CityDto() { Id = 2, Name = "Esfehan", Description = "hello from Esfahan", PointOfInterests = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto(){Id = 4, Name = "ambshar2", Description = "so good2"},
                    new PointOfInterestDto(){Id = 5, Name = "ambshar2", Description = "so good2"},
                    new PointOfInterestDto(){Id = 6, Name = "ambshar2", Description = "so good2"}
                }},
                new CityDto() { Id = 3, Name = "Mashhad", Description = "hello from Mashhad", PointOfInterests = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto(){Id = 7, Name = "ambshar3", Description = "so good3"},
                    new PointOfInterestDto(){Id = 8, Name = "ambshar3", Description = "so good3"},
                    new PointOfInterestDto(){Id = 9, Name = "ambshar3", Description = "so good3"}
                }}

            };
        }
    }
}
