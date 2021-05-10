using FreeChoiceDiscipline.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeChoiceDiscipline.DAL.Entities
{
    public class User
    {
        public int Id { get; set; } = 0;
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } = RoleType.Guest;


        //public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
    }
}
