using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{
    public class Roller
    {
        [Key]
        [Required]
        public int Rolle_ID { get; set; }

        [Required]
        public int Bruker_ID { get; set; }

        [Required]
        public string Ansvar { get; set; }

    }
}