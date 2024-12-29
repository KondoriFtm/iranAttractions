using iranAttractions.Models;

namespace iranAttractions.ViewModels
{
    public class SightseeingViewModel
    {
        public List<Comment> Comments { get; set; }

        public List<Picture> Pictures { get; set; }

        public List<HotelDistancesViewModel> Hot_Dis { get; set; }

       public List<ResturantDistancesViewModel> Res_Dis { get; set; }

        public Sightseeing sightseeing { get; set; }
    }
}
