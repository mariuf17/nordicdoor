using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{

    public class Team
    {
        [Key]
        public int Team_ID { get; set; }
        [Required]

        public int Avdeling_ID { get; set; }

        public string TeamNavn { get; set; }

    }
}
