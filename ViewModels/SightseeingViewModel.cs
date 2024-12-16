using iranAttractions.Models;

namespace iranAttractions.ViewModels
{
    public class SightseeingViewModel
    {
        public List<Comment> Comments { get; set; }

        public List<Picture> Pictures { get; set; }

        public PIctureViewModel PictureModel { get; set; }

        public Sightseeing sightseeing { get; set; }
    }
}
