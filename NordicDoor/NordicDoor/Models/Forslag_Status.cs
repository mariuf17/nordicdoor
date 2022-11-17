using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models
{
public class Forslag_Status
    {
    [Key]    
    public int Forslag_Status_ID { get; set; }

    [Required]
    public int Forslag_ID { get; set; }

    [Required]
    public DateTime Innsendt_Dato { get; set; }

    public DateTime Avsluttet_Dato { get; set; }

    public string FStatus { get; set; }

    public string Fase { get; set; }

    }
}