
using iranAttractions.Models;

namespace iranAttractions.ViewModels
{
    public class ProvinceViewModel
    {
        public string ProvinceName { get; set; }
        public string ProvinceDescription { get; set; }
        public List<Sightseeing> Sightseeings { get; set; }

        public City City { get; set; }
        
        //public List<HotelViewModel> Hotels { get; set; }
        //public List<RestaurantViewModel> Restaurants { get; set; }
    }
}
