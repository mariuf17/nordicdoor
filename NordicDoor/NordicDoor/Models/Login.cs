using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models.Users
{
	public class Login
	{
		[Key]
		[Required]
		public string Brukernavn { get; set; }

		[Required]
		public int Bruker_ID { get; set; }

		[Required]
		public string Epost { get; set; }

		[Required]
		public string Passord { get; set; }
	}
}

