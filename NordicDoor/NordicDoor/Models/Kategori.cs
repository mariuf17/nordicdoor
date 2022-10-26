using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models{
public class Kategori
    {
    [key]    
    public int Kategori_ID { get; set; }
    [Required]
    public int Forslag_ID { get; set; }

    public string Kategori { get; set; }

    }
}