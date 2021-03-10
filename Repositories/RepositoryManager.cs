using Contracts;
using FreeChoiceDiscipline.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private AppDbContext _repositoryContext;
        private IUserRepository _userRepository;
        private IDisciplineRepository _disciplineRepository;

        public RepositoryManager(AppDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_repositoryContext);
                return _userRepository;
            }
        }

        public IDisciplineRepository Discipline
        {
            get
            {
                if (_disciplineRepository == null)
                    _disciplineRepository = new DisciplineRepository(_repositoryContext);
                return _disciplineRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}
