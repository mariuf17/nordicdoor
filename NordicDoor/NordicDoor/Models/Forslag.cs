using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{
    public class Forslag
    {
        [Key]
        [Required]
        public int Forslag_ID { get; set; }

        [Required]
        public int Bruker_ID { get; set; }

        public int Team_ID { get; set; }

        [Required]
        public string Kategori_ID { get; set; }

        [Required]
        public DateOnly Start_Tid { get; set; } 

        public DateOnly Frist { get; set; }

        [Required]
        public string Tittel { get; set; }

        [Required]
        public string Beskrivelse { get; set; }

        [Required]
        public string Ansvarlig { get; set; }

    }
}

