using AutoMapper;
using Contracts;
using FreeChoiceDiscipline.DAL.Entities;
using FreeChoiceDiscipline.DAL.Models;
using FreeChoiceDiscipline.Profiles;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Testing.Repositories.Setup;
using Xunit;

namespace Testing.Repositories
{
    public class DisciplineRepositoryTests: BaseRepositorySetup
    {
        
        public DisciplineRepositoryTests()
        {
            _repositoryManager.Discipline.AddListOfDisciplines(defaultDisciplinesInDatabase);

            _repositoryManager.Save();
        }

        [Fact]
        public void CreateDiscipline_ShouldWorks()
        {
            var disciplineDto = new DisciplineToCreate
            {
                Title = "New discipline",
                IsOpenToRegistry = true,
                MaxAmountOfStudents = 10,
                CurrentAmountOfStudents = 2
            };

            var discipline = _mapper.Map<Discipline>(disciplineDto);

            _repositoryManager.Discipline.CreateDiscipline(discipline);
            _repositoryManager.Save();

            var disciplineToCheck = this._repositoryManager.Discipline.FindDisciplineByTitle(disciplineDto.Title, trackChanges: false);

            Assert.True(discipline.Equals(disciplineToCheck));
        }

        [Fact]
        public void CreateDisciplineThatIsAlreadyExists_ShouldFailed()
        {
            Assert.Throws<ArgumentException>(() => _repositoryManager.Discipline.CreateDiscipline(this.defaultDisciplinesInDatabase[0]));
        }

        [Fact]
        public void CreateDisciplineThatIsNull_ShouldFailed()
        {
            Assert.Throws<ArgumentNullException>(() => _repositoryManager.Discipline.CreateDiscipline(null));
        }



        [Fact]
        public void FindDisciplineByTitle_ShouldWorks()
        {
            var discipline = _repositoryManager.Discipline.FindDisciplineByTitle(this.defaultDisciplinesInDatabase[0].Title, trackChanges: false);

            Assert.True(discipline.Equals(this.defaultDisciplinesInDatabase[0]));
        }

        [Fact]
        public void FindDisciplineByTitle_ShouldFailed()
        {
            var discipline = _repositoryManager.Discipline.FindDisciplineByTitle("Unknown Discipline In A Database", trackChanges: false);

            Assert.Null(discipline);
        }

    }
}
