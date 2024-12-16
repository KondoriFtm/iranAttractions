namespace iranAttractions.Models
{
    public class Parts
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PicUrl { get; set; }
        public int SightseeingId { get; set; }
        public virtual Sightseeing Sightseeings { get; set; }


    }
}
