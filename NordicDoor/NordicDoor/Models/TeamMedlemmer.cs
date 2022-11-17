using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{

    public class Team_Medlemmer
    {
        [Key]
        public int Team_ID { get; set; }
        [Required]

        public int Bruker_ID { get; set; }

    }
}
