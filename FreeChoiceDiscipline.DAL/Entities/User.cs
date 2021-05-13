using FreeChoiceDiscipline.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeChoiceDiscipline.DAL.Entities
{
	public class User : IdentityUser
	{
		public int Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		//public string Username { get; set; }
		public string Role { get; set; } = RoleType.Guest;

		//public int DisciplineId { get; set; }
		public Discipline Discipline { get; set; }
	}
}
