using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models.Account
{
	public class Login
	{
		[Key]
		[Required]
		public string Brukernavn { get; set; }

		[Required]
		public string Bruker_ID { get; set; }

		[Required]
		[EmailAddress]
		public string Epost { get; set; }

		[Required]
        [DataType(DataType.Password)]
        public string Passord { get; set; }

        public bool IsAdmin { get; set; }

    }
}

