using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{

    public class Team
    {
        [Key]
        [Required]
        public int Team_ID { get; set; }

        [Required]
        public int Avdeling_ID { get; set; }

        [Required]
        public string Teamnavn { get; set; }

        public string AntallTeams { get; set; }
    }
}
