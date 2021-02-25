using System;
using System.Collections.Generic;
using System.Text;

namespace FreeChoiceDiscipline.DAL.Models
{
    public class DisciplineToModify
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public byte MaxAmountOfStudents { get; set; }
    }
}
