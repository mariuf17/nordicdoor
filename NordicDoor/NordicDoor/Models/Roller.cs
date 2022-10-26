using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{
    public class Roller
    {
        [Key]
        public int Rolle_ID { get; set; }
        [Required]
        public int Ansatt_ID { get; set; }

        public string Ansvar { get; set; }

    }
}