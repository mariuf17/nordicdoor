﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace NordicDoor.Models.Suggestions;

public class SuggestionViewModel
{
    [Required]
    [MinLength(7, ErrorMessage = "Skriv en ordentlig tittel!")]
    public string Title { get; set; }

    public string Name { get; set; }
    public int Team { get; set; }
    public string Description { get; set; }
    public string TimeStamp { get; set; }
}