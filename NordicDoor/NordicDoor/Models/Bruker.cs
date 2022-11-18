using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{
    public class Bruker
    {
        [Key]
        [DisplayName("Ansattnummer")]
        [Required]
        public int Bruker_ID { get; set; }

        [Required]
        public string Postnummer { get; set; }

        [Required]
        public string Navn { get; set; }

        [DisplayName("E-post")]
        [Required]
        public string Epost { get; set; }

        public int Telefon { get; set; }



    }
}

