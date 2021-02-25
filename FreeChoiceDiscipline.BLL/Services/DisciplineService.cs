using FreeChoiceDiscipline.DAL;
using FreeChoiceDiscipline.DAL.Entities;
using FreeChoiceDiscipline.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChoiceDiscipline.BLL.Services
{
    class DisciplineService : IDisciplineService
    {
        private readonly AppDbContext _context;

        public DisciplineService(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Discipline> PossibleDisciplines()
        {
            var disciplines = _context.Disciplines.Where(x => x.IsOpenToRegistry).ToList();


            return disciplines;
        }

        public async Task UpdateDiscipline(DisciplineToModify discipline)
        {
            _ = discipline ?? throw new NullReferenceException("A new discipline cannot be empty");

            var disciplineToUpdate = _context.Disciplines.FirstOrDefault(x => x.Id.Equals(discipline.Id));

            _ = disciplineToUpdate ?? throw new ArgumentException("Cannot find that discipline", nameof(discipline.Id));

            disciplineToUpdate.Title = discipline.Title;
            disciplineToUpdate.MaxAmountOfStudents = discipline.MaxAmountOfStudents;

            await SaveChanges();
        }

        public async Task DeleteDisciplineById(int disciplineId)
        {
            var discipline = _context.Disciplines.FirstOrDefault(x => x.Id.Equals(disciplineId));

            _ = discipline ?? throw new ArgumentException("Cannot find that discipline", nameof(disciplineId));

            _context.Disciplines.Remove(discipline);

            await SaveChanges();
        }

        public async Task CreateDiscipline(DisciplineToModify discipline)
        {
            _ = discipline ?? throw new NullReferenceException("A new discipline cannot be empty");

            bool disciplineIsAlreadyExists = _context.Disciplines.Any(x => x.Title == discipline.Title);

            if (disciplineIsAlreadyExists)
            {
                throw new ArgumentException("There is already a discipline " + discipline.Title, nameof(discipline));
            }
            var newDiscipline = new Discipline(discipline);
            _context.Disciplines.Add(newDiscipline);

            await SaveChanges();

        }


        private async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
