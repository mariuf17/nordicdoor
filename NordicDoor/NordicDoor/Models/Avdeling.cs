using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{

    public class Avdeling
    {
        [Key]
        public int Avdeling_ID { get; set; }
        [Required]

        public string Avdeling { get; set; }

    }
}
