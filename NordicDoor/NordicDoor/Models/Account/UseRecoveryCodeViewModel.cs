using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models.Account;

public class UseRecoveryCodeViewModel
{
    [Required]
    public string Code { get; set; }

    public string ReturnUrl { get; set; }
}

