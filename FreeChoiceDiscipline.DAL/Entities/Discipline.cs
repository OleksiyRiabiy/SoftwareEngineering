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


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Discipline user = obj as Discipline;
            if (user == null)
            {
                return false;
            }

            return Equals(user);
        }

        public bool Equals(Discipline discipline)
        {
            return Title == discipline.Title &&
                MaxAmountOfStudents.Equals(discipline.MaxAmountOfStudents) &&
                CurrentAmountOfStudents.Equals(discipline.CurrentAmountOfStudents) &&
                IsOpenToRegistry.Equals(discipline.IsOpenToRegistry);
        }

    }
}
