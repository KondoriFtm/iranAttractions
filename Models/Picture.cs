namespace iranAttractions.Models
{
    public class Picture
    {
        public int Id { get; set; }
        //public string FileName { get; set; }
        public string FilePath { get; set; }
        //public string ContentType { get; set; } // e.g., "image/jpeg"

        public DateTime dateImported { get; set; }

        public int likecounts { get; set; }

        public int SightseeingId { get; set; }

        public string UserPhonenumber { get; set; }


    }

}
