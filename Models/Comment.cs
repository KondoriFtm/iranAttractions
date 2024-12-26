
    namespace iranAttractions.Models
    {
        public class Comment
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int? State { get; set; }
            public DateTime? Date { get; set; }
            public int SightseeingId { get; set; }
            public string picurl {  get; set; }
            public string UserPhonenumber { get; set; } // Changed to string type
            public virtual User Users { get; set; }
            public virtual Sightseeing Sightseeings { get; set; }
        }
    }






