namespace iranAttractions.Models
{
    public class Sightseeing
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double lat { get; set; }

        public double lon { get; set; }

        public int CityId {  get; set; }

        public virtual City City { get; set; }
        public List<Comment> Comments { get; set; }

        public List<Parts> parts { get; set; }



    }
}
