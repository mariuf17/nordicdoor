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
    public DateOnly Innsendt_Dato { get; set; }

    public DateOnly Avsluttet_Dato { get; set; }

    public string FStatus { get; set; }

    public string Fase { get; set; }

    }
}