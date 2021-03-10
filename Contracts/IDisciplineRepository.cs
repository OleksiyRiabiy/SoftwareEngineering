using FreeChoiceDiscipline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IDisciplineRepository
    {
        void CreateDiscipline(Discipline discipline);
    }
}
