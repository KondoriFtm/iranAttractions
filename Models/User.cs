
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    namespace iranAttractions.Models
    {
        public class User
        {
            [Key]
           
            public string Phonenumber { get; set; } // Primary key

           
            public string UserName { get; set; }

              public string password { get; set; }
        public string Role {  get; set; }
            public virtual ICollection<Comment> Comments { get; set; }
            //public virtual List<Picture> Pictures { get; set; }
        }
    }


