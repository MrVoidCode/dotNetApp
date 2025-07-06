using System.ComponentModel.DataAnnotations;

namespace SimpleApi.models
{
    public class PointOfInterestUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

    }
}
