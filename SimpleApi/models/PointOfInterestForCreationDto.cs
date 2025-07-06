using System.ComponentModel.DataAnnotations;

namespace SimpleApi.models
{
    public class PointOfInterestForCreationDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }


    }
}
