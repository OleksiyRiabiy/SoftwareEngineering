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
	class DisciplineManager : RepositoryBase<Discipline>, IDisciplineRepository
	{

		public DisciplineManager(AppDbContext repositoryContext) : base(repositoryContext) { }
		private AppDbContext _repositoryContext;

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



		public void UpdateDiscipline(string title, Discipline discipline)
		{
			_ = discipline ?? throw new ArgumentNullException(nameof(discipline));

			var disciplineFromDb = FindDisciplineByTitle(discipline.Title, trackChanges: false);

			if (disciplineFromDb == null)
			{
				throw new ArgumentException($"Discipline with title {title} does not exists");
			}

			else
			{
				//TODO maper
				disciplineFromDb.Title = discipline.Title;
				disciplineFromDb.MaxAmountOfStudents = discipline.MaxAmountOfStudents;
				disciplineFromDb.CurrentAmountOfStudents = discipline.CurrentAmountOfStudents;
				disciplineFromDb.IsOpenToRegistry = discipline.IsOpenToRegistry;

				_repositoryContext.SaveChanges();
			}
		}



		public void DelateDiscipline(string title)
		{
			_ = title ?? throw new ArgumentNullException(nameof(title));

			var disciplineFromDb = FindDisciplineByTitle(title, trackChanges: false);

			if (disciplineFromDb == null)
			{
				throw new ArgumentException($"Discipline with title {title} does not exists");
			}

			else
			{
				_repositoryContext.Disciplines.Remove(disciplineFromDb);
				_repositoryContext.SaveChanges();
			}
		}



		public void Save() => _repositoryContext.SaveChanges();
	}
}
