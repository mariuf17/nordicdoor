using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{
    public class Forslag
    {
        [Key]
        public int Forslag_ID { get; set; }
        [Required]

        public int Bruker_ID { get; set; }

        public int Team_ID { get; set; }

        public int Forslag_Status_ID { get; set; }

        public int Kategori_ID { get; set; }

        public DateTime Start_Tid { get; set; }

        public DateTime Frist { get; set; }

        public string Tittel { get; set; }

    }
}

