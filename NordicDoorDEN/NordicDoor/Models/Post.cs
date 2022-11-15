using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{
    public class Post
    {
        [Key]
        public string Postnummer { get; set; }
        [Required]

        public string Adresse { get; set; }

    }
}

