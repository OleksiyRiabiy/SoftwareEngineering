using FreeChoiceDiscipline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Contracts
{
    public interface IDisciplineRepository
    {
        void CreateDiscipline(Discipline discipline);
        void AddListOfDisciplines(IEnumerable<Discipline> disciplines);
        IEnumerable<Discipline> GetAll(bool trackChanges);
        Discipline FindDisciplineByTitle(string title, bool trackChanges);
    }
}
