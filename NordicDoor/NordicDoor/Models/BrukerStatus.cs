using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{

    public class BrukerStatus
    {
        [Key]
        public int Bruker_Status_ID { get; set; }
        [Required]

        public int Bruker_ID { get; set; }

        public int AnsattStatus { get; set; }

    }
}
