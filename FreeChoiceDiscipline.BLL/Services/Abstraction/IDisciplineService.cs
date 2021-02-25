using FreeChoiceDiscipline.DAL.Entities;
using FreeChoiceDiscipline.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreeChoiceDiscipline.BLL.Services
{
    interface IDisciplineService
    {
        Task CreateDiscipline(DisciplineToModify discipline);
        Task DeleteDisciplineById(int disciplineId);
        List<Discipline> PossibleDisciplines();
        Task UpdateDiscipline(DisciplineToModify discipline);
    }
}