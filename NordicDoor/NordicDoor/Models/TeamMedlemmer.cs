using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{

    public class TeamMedlemner
    {
        [Key]
        public int Bruker_ID { get; set; }
        [Required]

        public int Team_ID { get; set; }

    }
}
