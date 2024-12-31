using System.ComponentModel.DataAnnotations;

namespace iranAttractions.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Sightseeing> sightseeings { get; set; }
        public List<Hotel> hotels { get; set; }
        public List<Resturant> resturants { get; set; }

        public int AttractionCount { get { return sightseeings != null ? sightseeings.Count : 0; } }

    }
}
