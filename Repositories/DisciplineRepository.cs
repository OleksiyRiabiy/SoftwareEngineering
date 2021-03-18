using Contracts;
using FreeChoiceDiscipline.DAL;
using FreeChoiceDiscipline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositories
{
    class DisciplineRepository: RepositoryBase<Discipline>, IDisciplineRepository
    {
        public DisciplineRepository(AppDbContext repositoryContext) : base(repositoryContext) { }

        public void CreateDiscipline(Discipline discipline)
        {
            _ = discipline ?? throw new ArgumentNullException(nameof(discipline));

            var disciplineFromDb = FindDisciplineByTitle(discipline.Title, trackChanges: false);

            if (disciplineFromDb != null)
            {
                throw new ArgumentException($"Discipline with title {discipline.Title} already exists");
            }

            Create(discipline);
        }
        
        public void AddListOfDisciplines(IEnumerable<Discipline> disciplines)
        {
            _ = disciplines ?? throw new ArgumentNullException(nameof(disciplines));

            CreateSet(disciplines);
        }

        public Discipline FindDisciplineByTitle(string title, bool trackChanges)
        {
            return FindByCondition(x => x.Title.Equals(title), trackChanges).FirstOrDefault();
        }

        public IEnumerable<Discipline> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges);
        }
    }
}
