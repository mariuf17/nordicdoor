using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{
    public class Bruker
    {
        [Key]
        public int Bruker_ID { get; set; }
        [Required]

        public string Postnummer { get; set; }

        public string Navn { get; set; }

        public string Epost { get; set; }

        public int Telefon { get; set; }

    }
}

