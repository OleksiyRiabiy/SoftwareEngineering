using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeChoiceDiscipline.DAL.Entities
{
    public class Discipline
    {
        public int Id { get; set; }
        public byte MaxAmountOfStudents { get; set; }

        public byte CurrentAmountOfStudents { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
