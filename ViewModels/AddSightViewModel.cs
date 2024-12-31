using Microsoft.AspNetCore.Mvc.Rendering;

namespace iranAttractions.ViewModels
{
    public class AddSightViewModel
    {
        public string Name {  get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }
        public double lat {  get; set; }
        public double lon { get; set; }
        public int SelectedOptionId { get; set; }
        public List<SelectListItem> CityLists { get; set; }
    }
}
