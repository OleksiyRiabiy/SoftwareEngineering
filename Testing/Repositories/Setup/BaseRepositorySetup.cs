using AutoMapper;
using Contracts;
using FreeChoiceDiscipline.DAL;
using FreeChoiceDiscipline.DAL.Entities;
using FreeChoiceDiscipline.Enums;
using FreeChoiceDiscipline.Profiles;
using Helpers;
using Microsoft.EntityFrameworkCore;
using Moq;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testing.Repositories.Setup
{
    public class BaseRepositorySetup
    {
        protected static readonly DbContextOptions<AppDbContext> options;
        protected readonly AppDbContext _context;
        protected readonly IRepositoryManager _repositoryManager;
        protected readonly IMapper _mapper;
        protected readonly List<User> defaultUsersInDatabase;
        protected readonly List<Discipline> defaultDisciplinesInDatabase;

        static BaseRepositorySetup()
        {
            options = new DbContextOptionsBuilder<AppDbContext>()
                         .UseInMemoryDatabase(databaseName: "DefaultConnection")
                         .Options;

        }

        public BaseRepositorySetup()
        {
            _context = new AppDbContext(options);
            _repositoryManager = new RepositoryManager(_context);

            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            defaultUsersInDatabase = DefaultUsers();
            defaultDisciplinesInDatabase = DefaultDisciplines();
        }

        private List<User> DefaultUsers()
        {
            return new List<User>
            {
                new User { Firstname = "FirstName1", Lastname = "LastName1", Role = RoleType.User, PasswordHash = "password".HashPassword() },
                new User { Firstname = "FirstName2", Lastname = "LastName2", Role = RoleType.Guest, PasswordHash = "password1".HashPassword() },
                new User { Firstname = "FirstName3", Lastname = "LastName3", Role = RoleType.Admin, PasswordHash = "password2".HashPassword() },
            };
        }

        private List<Discipline> DefaultDisciplines()
        {
            return new List<Discipline>
            {
                new Discipline{ Title = "Discipline1", IsOpenToRegistry = true, MaxAmountOfStudents = 100, CurrentAmountOfStudents = 30},
                new Discipline{ Title = "Discipline2", IsOpenToRegistry = true, MaxAmountOfStudents = 20, CurrentAmountOfStudents = 19},
                new Discipline{ Title = "Discipline3", IsOpenToRegistry = false, MaxAmountOfStudents = 80, CurrentAmountOfStudents = 50}
            };
        }

        private static DbSet<T> ConvertToDbSet<T>(IEnumerable<T> list) where T : class, new()
        {
            IQueryable<T> queryableList = list.AsQueryable();
            Mock<DbSet<T>> dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryableList.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableList.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(queryableList.GetEnumerator());
            return dbSetMock.Object;
        }

    }
}
