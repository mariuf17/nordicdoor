using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models.Account;

public class ExternalLoginConfirmationViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}

