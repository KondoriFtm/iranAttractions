﻿using System.ComponentModel.DataAnnotations;

namespace iranAttractions.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Sightseeing> sightseeings { get; set; }
    }
}