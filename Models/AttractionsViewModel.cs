using System.ComponentModel.DataAnnotations;

namespace iranAttractions.Models
{
    public class AttractionsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }


    }
}
