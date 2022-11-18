using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{

    public class Avdeling
    {
        [Key]
        [Required]
        public int Avdeling_ID { get; set; }

        [Required]
        public string? Avdelinger { get; set; }

    }
}
