namespace iranAttractions.Models
{
    public class Hotel
    {
        public int Id {  get; set; }
        public string Name { get; set; }

        public string address { get; set; }

        public double lat { get; set; }

        public double lon { get; set; }

        public int cityId { get; set; }

        public City City { get; set; }
    }
}
