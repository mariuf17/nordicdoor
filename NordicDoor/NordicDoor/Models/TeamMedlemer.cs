using System;
using System.ComponentMOdel.Dataannotations;

namespace NordicDoor.Models

public class TeamMedlemer
{
    [key]    
    public int Bruker_ID { get; set; }
    [Required]
    public int Team_ID { get; set; }

}
