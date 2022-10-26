using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models{
public class Kategori
    {
    [Key]    
    public int Kategori_ID { get; set; }
    [Required]
    public int Forslag_ID { get; set; }

    public string Kategorier { get; set; }

    }
}