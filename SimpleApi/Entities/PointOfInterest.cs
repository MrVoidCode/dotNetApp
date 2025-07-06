using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApi.Entities
{
    public class PointOfInterest
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string? Description { get; set; }

        // relation
        [ForeignKey("CityId")]
        public City City { get; set; }
        public int CityId { get; set; }

        public PointOfInterest(string name)
        {
            this.Name = name;
        }

    }
}
