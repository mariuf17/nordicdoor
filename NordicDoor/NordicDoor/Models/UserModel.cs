using System;
using System.ComponentModel.DataAnnotations;

namespace NordicDoor.Models.Users
{
	public class UserModel
	{
		[Key]
		[Required]
		public string Brukernavn { get; set; }

		public int Bruker_ID { get; set; }

		public string Epost { get; set; }

		[Required]
		public string Passord { get; set; }

		[Required]
		public string Rolle { get; set; }
	}
}

