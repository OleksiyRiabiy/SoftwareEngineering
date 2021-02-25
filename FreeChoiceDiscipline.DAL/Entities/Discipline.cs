using FreeChoiceDiscipline.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeChoiceDiscipline.DAL.Entities
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Title { get; set; } //unique
        public byte MaxAmountOfStudents { get; set; }

        public byte CurrentAmountOfStudents { get; set; }
        public bool IsOpenToRegistry { get; set; } = true;

        public ICollection<User> Users { get; set; }

        public Discipline(DisciplineToModify discipline)
        {
            Title = discipline.Title;
            MaxAmountOfStudents = discipline.MaxAmountOfStudents;
        }
    }
}
