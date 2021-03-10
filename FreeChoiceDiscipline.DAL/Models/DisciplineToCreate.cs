using System;
using System.Collections.Generic;
using System.Text;

namespace FreeChoiceDiscipline.DAL.Models
{
    public class DisciplineToCreate
    {
        public string Title { get; set; } //unique
        public byte MaxAmountOfStudents { get; set; }

        public byte CurrentAmountOfStudents { get; set; }
        public bool IsOpenToRegistry { get; set; } 
    }
}
