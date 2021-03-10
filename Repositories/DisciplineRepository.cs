using Contracts;
using FreeChoiceDiscipline.DAL;
using FreeChoiceDiscipline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    class DisciplineRepository: RepositoryBase<Discipline>, IDisciplineRepository
    {
        public DisciplineRepository(AppDbContext repositoryContext) : base(repositoryContext) { }

        public void CreateDiscipline(Discipline discipline) => Create(discipline);
    }
}
